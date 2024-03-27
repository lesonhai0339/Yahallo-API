using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories
{
    public interface IEFRepository<TDomain, TPersistence> : IRepository<TDomain>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TDomain?> FindAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<TDomain?> FindAsync(Expression<Func<TPersistence, bool>> filterExpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<TDomain?> FindAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpression, CancellationToken cancellationToken = default);

        Task<List<TDomain>> FindAllAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);
        Task<int> CountAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        // Query TClass and then mapping to Tsource destinition
        // {example => var result= _TclassRepo.FindAllProjectToAsync<TClassDto>(condition)}
        Task<List<TProjection>> FindAllProjectToAsync<TProjection>(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<IPagedResult<TProjection>> FindAllProjectToAsync<TProjection>(int pageNo, int pageSize, Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default, CancellationToken cancellationToken = default);
        Task<TProjection?> FindProjectToAsync<TProjection>(Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions, CancellationToken cancellationToken = default);

        Task<Dictionary<TKey, TValue>> FindAllToDictionaryAsync<TKey, TValue>(
            Expression<Func<TPersistence, bool>> filterExpression,
            Expression<Func<TPersistence, TKey>> keySelector,
            Expression<Func<TPersistence, TValue>> valueSelector,
            CancellationToken cancellationToken = default);

        //custom
        /// <summary>
        /// Use sql raw to query
        /// </summary>
        /// <param name="query">string</param>
        /// <param name="cancellationToken"></param>
        /// <param name="paramenter"></param>
        /// <returns>List<TPersistence></returns>
        Task<List<TPersistence>> FindBySQLRaw(
           string query,
           CancellationToken cancellationToken = default,
           params object[] paramenter);
        /// <summary>
        /// Create iqueryable with equal condition
        /// </summary>
        /// <param name="request">TPersistence</param>
        /// <returns>Func<IQueryable<TPersistence>, IQueryable<TPersistence>></returns>
        Func<IQueryable<TPersistence>, IQueryable<TPersistence>> IQueryableHandlerEqual(object request);
        /// <summary>
        /// Create Expression with equal condition
        /// </summary>
        /// <param name="request">TPersistence</param>
        /// <returns>Expression<Func<TPersistence, bool>></returns>
        Expression<Func<TPersistence, bool>>? IExpressionEqual(PropertyInfo pro, object value);
        /// <summary>
        /// Create iqueryable with condition that Expression can understand
        /// </summary>
        /// <param name="request">TPersistence, Expression</param>
        /// <returns>Func<IQueryable<TPersistence>, IQueryable<TPersistence>></returns>
        Func<IQueryable<TPersistence>, IQueryable<TPersistence>> IQueryableHandlerMultiple(
           object request,
           Func<Expression, Expression, BinaryExpression> expression);
        /// <summary>
        /// Create Expression with condition that Expression can understand
        /// </summary>
        /// <param name="request">TPersistence</param>
        /// <returns>Expression<Func<TPersistence, bool>></returns>
        Expression<Func<TPersistence, bool>>? IExpressionMultiple
            (PropertyInfo pro,
            object value,
            Func<Expression, Expression, BinaryExpression> expression);
        /// <summary>
        /// Crreate and return Iqueryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TPersistence> CreateQueryable();
        //Find all to page result with iqueryable
        Task<IPagedResult<TDomain>> FindAllAsync(
            IQueryable<TPersistence> filterExpression,
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default);
        Task<TDomain?> FindAsync(
            IQueryable<TPersistence> iqueryable,
            CancellationToken cancellationToken = default);
    }
}
