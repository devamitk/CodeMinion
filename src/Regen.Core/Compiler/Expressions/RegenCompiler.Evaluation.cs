﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Regen.Compiler.Helpers;
using Regen.DataTypes;
using Regen.Helpers;
using Array = Regen.DataTypes.Array;
using ExpressionCompileException = Regen.Exceptions.ExpressionCompileException;

namespace Regen.Compiler.Expressions {
    public partial class RegenCompiler {
        #region Evaluation

        public object _evaluate(string expression, Line line = null) {
            //Core evaluation method.
            try {
                return Context.CompileDynamic(expression).Evaluate();
            } catch (Flee.PublicTypes.ExpressionCompileException e) {
                throw new Regen.Exceptions.ExpressionCompileException($"Was unable to evaluate expression: {expression}\t  At line ({line?.LineNumber}): {line?.Content}", e);
            }
        }

        protected object _evaluate(Expression expression, Line line = null) {
            return _evaluate(expression.AsString(), line);
        }

        public Data EvaluateExpression(Expression expression, Type _caller = null) {
            //todo make private
            var temps = new List<TemporaryVariable>();
            expression = Expand(expression, temps, typeof(RegenCompiler));
            try {
                return Eval(expression, temps, _caller);
            } finally {
                temps.ForEach(t => t.Dispose());
            }
        }

        private Data Eval(Expression expression, List<TemporaryVariable> temps, Type _caller = null) {
            return _eval(expression, _caller);

            Data _eval(Expression express, Type caller = null) {
                switch (express) {
                    case null:
                        throw new NullReferenceException();
                    case ArgumentsExpression argumentsExpression: {
                        var arr = new Array();
                        foreach (var expr in argumentsExpression.Arguments) {
                            arr.Add(_eval(expr));
                        }

                        return arr;
                    }

                    case ArrayExpression arrayExpression: {
                        var arr = new Array();
                        foreach (var expr in arrayExpression.Values) {
                            arr.Add(_eval(expr));
                        }

                        return arr;
                    }

                    case NumberLiteral numberLiteral: {
                        return new NumberScalar(_evaluate(numberLiteral.Value));
                    }

                    case BooleanLiteral booleanLiteral: {
                        return new BoolScalar(booleanLiteral.Value);
                    }

                    case CharLiteral charLiteral: {
                        return new StringScalar(charLiteral.Value.ToString());
                    }

                    case NullIdentity nullIdentity: {
                        return Data.Null;
                    }

                    case StringLiteral stringLiteral: {
                        return new StringScalar(stringLiteral.Value);
                    }

                    case KeyValueExpression keyValueExpression: {
                        //todo create a KeyValue regen data type.
                        return new NetObject(new KeyValuePair<object, object>(_eval(keyValueExpression.Key), _eval(keyValueExpression.Value)));
                    }

                    case EmptyExpression emptyExpression: {
                        return Data.Null;
                    }

                    case ForeachExpression foreachExpression: {
                        break;
                    }

                    case GroupExpression groupExpression: {
                        return _eval(groupExpression.InnerExpression);
                    }

                    case ReferenceIdentity referenceIdentity: {
                        if (!Context.Variables.ContainsKey(referenceIdentity.Name))
                            return new ReferenceData(referenceIdentity.Name);
                        return Data.Create(Context.Variables[referenceIdentity.Name]);
                    }

                    case PropertyIdentity propertyIdentity: {
                        var left = _eval(propertyIdentity.Left);
                        if (left is StringScalar sc) return Data.Create(_evaluate($"{sc.Value}.{propertyIdentity.Right.AsString()}"));
                        if (left is ReferenceData rf) {
                            var right = new PropertyIdentity(IdentityExpression.WrapVariable(rf.EmitExpressive()), propertyIdentity.Right).AsString();

                            return Data.Create(_evaluate(right));
                        }

                        using (var var = new TemporaryVariable(Context, left is NetObject no ? no.Value : left)) {
                            var right = new PropertyIdentity(IdentityExpression.WrapVariable(var.Name), propertyIdentity.Right).AsString();

                            return Data.Create(_evaluate(right));
                        }
                    }

                    case StringIdentity stringIdentity: {
                        return new ReferenceData(stringIdentity.Name);
                    }

                    case IdentityExpression identityExpression: {
                        return _eval(identityExpression.Identity, caller); //todo test
                    }

                    case Identity identity: {
                        throw new NotSupportedException();
                    }

                    case CallExpression callExpression: {
                        var left = _eval(callExpression.FunctionName, typeof(CallExpression));
                        var args = (Array) _eval(callExpression.Arguments);


                        if (left is NetObject || left is Array || left is Dictionary) goto _storing;
                        //try regular parsing:
                        try {
                            var parsed = $"{left.Emit()}({args.Select(arg => arg.EmitExpressive()).StringJoin(", ")})";
                            return Data.Create(_evaluate(parsed));
                        } catch (ExpressionCompileException) { }

                        _storing: //try storing left as variable
                        using (var var = new TemporaryVariable(Context, left is NetObject no ? no.Value : left)) {
                            var parsed = $"{var.Name}({args.Select(arg => arg.EmitExpressive()).StringJoin(", ")})";
                            return Data.Create(_evaluate(parsed));
                        }
                    }

                    case IndexerCallExpression indexerCallExpression: {
                        var left = Data.Create(_eval(indexerCallExpression.Left, typeof(IndexerCallExpression)));
                        var args = (Array) _eval(indexerCallExpression.Arguments);

                        if (left is NetObject || left is Array || left is Dictionary) goto _storing;
                        //try regular parsing:
                        try {
                            var parsed = $"{left.Emit()}[{args.Select(arg => arg.EmitExpressive()).StringJoin(", ")}]";
                            return Data.Create(_evaluate(parsed));
                        } catch (ExpressionCompileException) { }

                        _storing: //try storing left as variable
                        using (var var = new TemporaryVariable(Context, left is NetObject no ? no.Value : left)) {
                            var parsed = $"{var.Name}[{args.Select(arg => arg.EmitExpressive()).StringJoin(", ")}]";
                            return Data.Create(_evaluate(parsed));
                        }
                    }

                    case NewExpression newExpression: {
                        //todo new
                        break;
                    }

                    case LeftOperatorExpression leftOperatorExpression: {
                        foreach (var e in leftOperatorExpression.Iterate()) {
                            if (e is ArrayExpression) throw new NotSupportedException("Unable to compile a nested array, please define it in a variable first.");
                        }

                        return Data.Create(_evaluate(leftOperatorExpression.AsString()));
                    }

                    case OperatorExpression operatorExpression: {
                        foreach (var e in operatorExpression.Iterate()) {
                            if (e is ArrayExpression) throw new NotSupportedException("Unable to compile a nested array, please define it in a variable first.");
                        }

                        return Data.Create(_evaluate(operatorExpression.AsString()));
                    }

                    case RightOperatorExpression rightOperatorExpression: {
                        foreach (var e in rightOperatorExpression.Iterate()) {
                            if (e is ArrayExpression) throw new NotSupportedException("Unable to compile a nested array, please define it in a variable first.");
                        }

                        return Data.Create(_evaluate(rightOperatorExpression.AsString()));
                    }

                    case ThrowExpression throwExpression: {
                        break;
                    }

                    case VariableDeclarationExpression variableExpression: {
                        var name = Data.Create(_eval(variableExpression.Name));
                        if (name.GetType() != typeof(StringScalar)) throw new NotSupportedException("Variable names can contain only _azAZ0-9");
                        var value = Data.Create(_eval(variableExpression.Right));
                        Context.Variables[name.ToString()] = value;
                        return value;
                    }
                }

                return Data.Null;
            }
        }

        public class ReferenceIdentity : Identity {
            protected static readonly string _literalRegex;
            protected RegexResult _match;

            static ReferenceIdentity() {
                _literalRegex = ExpressionToken.Literal.GetAttribute<ExpressionTokenAttribute>().Regex;
            }

            public string Name { get; set; }

            protected ReferenceIdentity(string name) {
                Name = name;
            }

            public ReferenceIdentity(string name, RegexResult res) {
                Name = name;
                _match = res;
            }

            public static ReferenceIdentity Create(Match match) {
                var name = match.Value;
                if (!Regex.IsMatch(name, _literalRegex, Regexes.DefaultRegexOptions))
                    throw new ExpressionException($"The name '{name}' contains invalid symbols. Regex Pattern: {_literalRegex}");
                return new ReferenceIdentity(name) {_match = match.AsResult()};
            }

            public static ReferenceIdentity Parse(ExpressionWalker ew) {
                //types:
                //justname
                ew.IsCurrentOrThrow(ExpressionToken.Literal);
                var ret = new ReferenceIdentity(ew.Current.Match.Value) {_match = ew.Current.Match.AsResult()};
                ew.Next();
                return ret;
            }

            public override IEnumerable<RegexResult> Matches() {
                yield return _match;
            }

            #region Equality

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <param name="other">An object to compare with this object.</param>
            /// <returns>
            /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
            public bool Equals(ReferenceIdentity other) {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(Name, other.Name);
            }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <param name="other">An object to compare with this object.</param>
            /// <returns>
            /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
            public bool Equals(string other) {
                return Equals(other, Name);
            }

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <param name="other">An object to compare with this object.</param>
            /// <returns>
            /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
            public bool Equals(StringLiteral other) {
                return Equals(other?.Value, Name);
            }

            /// <summary>Determines whether the specified object is equal to the current object.</summary>
            /// <param name="obj">The object to compare with the current object. </param>
            /// <returns>
            /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
            public override bool Equals(object obj) {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ReferenceIdentity) obj);
            }

            /// <summary>Serves as the default hash function. </summary>
            /// <returns>A hash code for the current object.</returns>
            public override int GetHashCode() {
                return (Name != null ? Name.GetHashCode() : 0);
            }

            /// <summary>Returns a value that indicates whether the values of two <see cref="T:Regen.Compiler.Expressions.StringIdentity" /> objects are equal.</summary>
            /// <param name="left">The first value to compare.</param>
            /// <param name="right">The second value to compare.</param>
            /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
            public static bool operator ==(ReferenceIdentity left, ReferenceIdentity right) {
                return Equals(left, right);
            }

            /// <summary>Returns a value that indicates whether two <see cref="T:Regen.Compiler.Expressions.StringIdentity" /> objects have different values.</summary>
            /// <param name="left">The first value to compare.</param>
            /// <param name="right">The second value to compare.</param>
            /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
            public static bool operator !=(ReferenceIdentity left, ReferenceIdentity right) {
                return !Equals(left, right);
            }

            #endregion

            public static ReferenceIdentity Wrap(StringIdentity iden) {
                return new ReferenceIdentity(iden.Name, iden.Matches().First());
            }
        }

        public Expression Expand(Expression expr, List<TemporaryVariable> temps, Type caller = null) {
            //todo after we support dictionaries, add support here
            switch (expr) {
                case NullIdentity nullIdentity:
                case CharLiteral charLiteral:
                case NumberLiteral numberLiteral:
                case StringLiteral stringLiteral:
                case BooleanLiteral booleanLiteral:
                case StringIdentity stringIdentity:
                case ReferenceIdentity functionIdentity:
                case EmptyExpression emptyExpression:
                    return expr;
                case ArgumentsExpression argumentsExpression: {
                    for (var i = 0; i < argumentsExpression.Arguments.Length; i++) {
                        argumentsExpression.Arguments[i] = Expand(argumentsExpression.Arguments[i], temps, typeof(ArgumentsExpression));
                    }

                    return argumentsExpression;
                }

                case ArrayExpression arrayExpression: {
                    for (var i = 0; i < arrayExpression.Values.Length; i++) {
                        arrayExpression.Values[i] = Expand(arrayExpression.Values[i], temps, typeof(ArrayExpression));
                    }

                    var parsedArray = Eval(arrayExpression, temps, typeof(ArrayExpression));
                    var temp = new TemporaryVariable(Context, parsedArray);
                    //todo this might lead to memory leaks!
                    //temps.Add(temp);
                    //if (caller == typeof(RegenCompiler)) { //if this is the first expression that is being parsed
                    //    temp.MarkPermanent(); 
                    //}
                    return IdentityExpression.WrapVariable(temp.Name);
                }

                case IndexerCallExpression indexerCallExpression: {
                    indexerCallExpression.Left = Expand(indexerCallExpression.Left, temps, typeof(IndexerCallExpression));
                    indexerCallExpression.Arguments = (ArgumentsExpression) Expand(indexerCallExpression.Arguments, temps, typeof(IndexerCallExpression));
                    return indexerCallExpression;
                }

                case CallExpression callExpression: {
                    callExpression.FunctionName = Expand(callExpression.FunctionName, temps, typeof(CallExpression));
                    callExpression.Arguments = (ArgumentsExpression) Expand(callExpression.Arguments, temps, typeof(CallExpression));
                    return callExpression;
                }

                case IdentityExpression identityExpression: {
                    if (caller == typeof(CallExpression) || caller == typeof(IndexerCallExpression)) {
                        if (identityExpression.Identity is StringIdentity sr) {
                            if (!Context.Variables.ContainsKey(sr.Name)) {
                                return new IdentityExpression(ReferenceIdentity.Wrap(sr));
                            }
                        }
                    }

                    identityExpression.Identity = Expand(identityExpression.Identity, temps, caller ?? typeof(IdentityExpression));
                    return identityExpression;
                }

                case HashtagReferenceExpression hashtagReference: {
                    var key = $"__{hashtagReference.Number}__";
                    return new IdentityExpression(new ReferenceIdentity(key, new RegexResult() {Value = key, Index = hashtagReference.Matches().First().Index, Length = 1 + hashtagReference.Number.Length}));
                }

                case GroupExpression groupExpression:
                    groupExpression.InnerExpression = Expand(groupExpression.InnerExpression, temps, caller ?? typeof(GroupExpression));
                    return groupExpression;
                case PropertyIdentity propertyIdentity:
                    //todo maybe here we parse Left, store and push? but first invalidate that it is not just a name.
                    propertyIdentity.Left = Expand(propertyIdentity.Left, temps, caller ?? typeof(PropertyIdentity));
                    propertyIdentity.Right = Expand(propertyIdentity.Right, temps, caller ?? typeof(PropertyIdentity));
                    return propertyIdentity;
                case KeyValueExpression keyValueExpression:
                    keyValueExpression.Key = Expand(keyValueExpression.Key, temps, typeof(KeyValueExpression));
                    keyValueExpression.Value = Expand(keyValueExpression.Value, temps, typeof(KeyValueExpression));
                    return keyValueExpression;
                case NewExpression newExpression:
                    newExpression.Constructor = Expand(newExpression.Constructor, temps, typeof(NewExpression));
                    return newExpression;
                case LeftOperatorExpression leftOperatorExpression:
                    leftOperatorExpression.Right = Expand(leftOperatorExpression.Right, temps, typeof(LeftOperatorExpression));
                    return leftOperatorExpression;
                case OperatorExpression operatorExpression:
                    operatorExpression.Left = Expand(operatorExpression.Left, temps, typeof(OperatorExpression));
                    operatorExpression.Right = Expand(operatorExpression.Right, temps, typeof(OperatorExpression));
                    return operatorExpression;
                case RightOperatorExpression rightOperatorExpression:
                    rightOperatorExpression.Left = Expand(rightOperatorExpression.Left, temps, typeof(RightOperatorExpression));
                    return rightOperatorExpression;
                case ThrowExpression throwExpression:
                    throwExpression.Right = Expand(throwExpression.Right, temps, typeof(ThrowExpression));
                    return throwExpression;
                case ForeachExpression foreachExpression:
                    throw new NotSupportedException(); //todo support? this should be found in an expression. it is a higher level expression
                case ImportExpression importExpression:
                    throw new NotSupportedException(); //todo support? this should be found in an expression. it is a higher level expression
                case InteractableExpression interactableExpression:
                    throw new NotSupportedException(); //todo support? this should be found in an expression. it is a higher level expression
                case VariableDeclarationExpression variableExpression:
                    throw new NotSupportedException(); //todo support? this should be found in an expression. it is a higher level expression
                case Identity identity: //this is an abstract class.
                    throw new NotSupportedException();
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
}