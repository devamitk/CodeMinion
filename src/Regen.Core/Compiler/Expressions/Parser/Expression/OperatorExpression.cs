﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Regen.Exceptions;
using Regen.Helpers;

namespace Regen.Compiler.Expressions {
    /// <summary>
    ///     Parses 1 + 1
    /// </summary>
    public class OperatorExpression : Expression, IOperatorExpression {
        public Expression Left;
        public ExpressionToken Op;
        public Expression Right;

        public OperatorExpression(Expression lexpr, ExpressionToken op, Expression rexpr) {
            Left = lexpr;
            Op = op;
            Right = rexpr;
        }

        private OperatorExpression() { }

        public static bool IsNextAnOperation(ExpressionWalker ew) {
            if (!ew.HasNext)
                return false;

            using (ew.CheckPoint()) {
                ew.Next();
                return IsCurrentAnOperation(ew);
            }
        }

        public static bool IsCurrentAnOperation(ExpressionWalker ew) {
            switch (ew.Current.Token) {
                case ExpressionToken.Increment:
                case ExpressionToken.Decrement:
                case ExpressionToken.Add:
                case ExpressionToken.Sub:
                case ExpressionToken.Pow:
                case ExpressionToken.Mul:
                case ExpressionToken.Div:
                //case ExpressionToken.Mod:
                case ExpressionToken.DoubleEqual:
                case ExpressionToken.NotEqual:
                case ExpressionToken.Equal:
                case ExpressionToken.DoubleAnd:
                case ExpressionToken.And:
                case ExpressionToken.DoubleOr:
                case ExpressionToken.Or:
                case ExpressionToken.Not:
                case ExpressionToken.Xor:
                case ExpressionToken.ShiftRight:
                case ExpressionToken.BiggerOrEqualThat:
                case ExpressionToken.BiggerThan:
                case ExpressionToken.ShiftLeft:
                case ExpressionToken.SmallerOrEqualThat:
                case ExpressionToken.SmallerThan:
                case ExpressionToken.RangeTo:
                    return true;
                case ExpressionToken.NullCoalescing:
                    return true; //todo make a specific custom op expression for null coalescing.
                default:
                    return false;
            }
        }

        public static Expression Parse(ExpressionWalker ew, Expression left = null) {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var ret = new OperatorExpression();
            ret.Left = left ?? ParseExpression(ew, typeof(OperatorExpression));
            if (!IsCurrentAnOperation(ew))
                return left;
            ret.Op = ew.Current.Token;
            ew.NextOrThrow();
            ret.Right = ParseExpression(ew, typeof(OperatorExpression));
            return ret;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ExpressionToken IOperatorExpression.Op {
            get => Op;
            set => Op = value;
        }

        public override IEnumerable<RegexResult> Matches() {
            foreach (var match in Left.Matches()) {
                yield return match;
            }

            yield return Op.GetAttribute<ExpressionTokenAttribute>().Emit.AsResult();

            foreach (var match in Right.Matches()) {
                yield return match;
            }
        }

        public override IEnumerable<Expression> Iterate() {
            return this.Yield().Concat(Left.Iterate()).Concat(Right.Iterate());
        }
    }
}