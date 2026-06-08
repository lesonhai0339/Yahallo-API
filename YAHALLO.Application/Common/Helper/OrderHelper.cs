using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Common.Helper
{
    internal static  class OrderHelper
    {
        public static IOrderedQueryable<T> ApplyOrder<T, TKey>(
            IQueryable<T> query,
            Expression<Func<T, TKey>> keySelector,
            bool descending)
                {
                    return descending
                        ? query.OrderByDescending(keySelector)
                        : query.OrderBy(keySelector);
                }
    }
}
