using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Common
{
    public static class ExpressionHelpers
    {
        public static readonly Func<Expression, Expression, BinaryExpression> Equal =
               (property, constant) => Expression.Equal(property, constant);

        public static readonly Func<Expression, Expression, BinaryExpression> GreaterThan =
            (property, constant) => Expression.GreaterThan(property, constant);
    }
}
