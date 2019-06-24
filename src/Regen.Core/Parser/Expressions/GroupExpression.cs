﻿using System.Collections.Generic;
using System.Linq;
using Regen.Exceptions;
using Regen.Helpers;

namespace Regen.Parser.Expressions {
    public class GroupExpression : Expression {
        private RegexResult _matchLeft;
        private RegexResult _matchRight;
        public Expression InnerExpression { get; set; }

        public static GroupExpression Parse(ExpressionWalker ew, ExpressionToken left, ExpressionToken right) {
            var grp = new GroupExpression() {_matchLeft = AttributeExtensions.GetAttribute<ExpressionTokenAttribute>(left).Emit.AsResult(), _matchRight = AttributeExtensions.GetAttribute<ExpressionTokenAttribute>(right).Emit.AsResult()};
            ew.IsCurrentOrThrow(left);

            ew.NextOrThrow();
            if (ew.Current.Token == right)
                throw new UnexpectedTokenException($"Expected an expression, found end of group of type {right}");

            grp.InnerExpression = ParseExpression(ew);
            ew.IsCurrentOrThrow(right);
            ew.Next();
            return grp;
        }

        public override IEnumerable<RegexResult> Matches() {
            yield return _matchLeft;
            foreach (var match in InnerExpression.Matches()) {
                yield return match;
            }

            yield return _matchRight;
        }


        public override IEnumerable<Expression> Iterate() {
            return this.Yield().Concat(InnerExpression.Iterate());
        }
    }
}