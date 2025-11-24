using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IElasticQueryBuilder<T>
    {
        Task<bool> AddAsync(T index, CancellationToken token);
        IElasticQueryBuilder<T> Or(Expression<Func<T, bool>> predicate);
        IElasticQueryBuilder<T> Match(Expression<Func<T, object>> field, string value);
        IElasticQueryBuilder<T> Term(Expression<Func<T, object>> field, object value);
        Task Update(T doc, CancellationToken token);
        Task<IEnumerable<T>> SearchAsync(CancellationToken token = default);
        Task<IEnumerable<T>> ExecuteAsync(CancellationToken token = default);

    }
}
