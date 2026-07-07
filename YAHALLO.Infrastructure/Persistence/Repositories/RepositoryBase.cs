using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<TDomain, TPersistence, TDbContext> : IEFRepository<TDomain, TPersistence>
       where TDbContext : DbContext, IUnitOfWork
       where TPersistence : class, TDomain
       where TDomain : class
    {
        private readonly TDbContext _dbContext;
        private readonly IMapper _mapper;

        public RepositoryBase(TDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public IUnitOfWork UnitOfWork => _dbContext;
        public virtual void Remove(TDomain entity)
        {
            GetSet().Remove((TPersistence)entity);
        }
        public virtual void RemoveRange(IEnumerable<TDomain> entities)
        {
            GetSet().RemoveRange((List<TPersistence>)entities);
        }
        public virtual void Add(TDomain entity)
        {
            GetSet().Add((TPersistence)entity);
        }
        public virtual void Update(TDomain entity)
        {
            GetSet().Update((TPersistence)entity);
        }
        public virtual async Task<TDomain?> WhenAll(
            Expression<Func<TPersistence, bool>> filterExpression,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }
        public virtual async Task<TDomain?> FindAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            bool ignoreQueryFilters = false)
        {
            return await QueryInternal(filterExpression, ignoreQueryFilters).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<TDomain?> FindAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression, queryOptions).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<List<TDomain>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await QueryInternal(x => true).ToListAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<List<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            CancellationToken cancellationToken = default,
            bool ignoreQueryFilters = false)
        {
            return await QueryInternal(filterExpression, ignoreQueryFilters).ToListAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<List<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression, queryOptions).ToListAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(x => true);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }

        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default,
            bool ignoreQueryFilters = false)
        {
            var query = QueryInternal(filterExpression, ignoreQueryFilters);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }

        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            int pageNo,
            int pageSize,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(filterExpression, queryOptions);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }
        public virtual async Task<int> CountAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).CountAsync(cancellationToken);
        }

        public bool Any(Expression<Func<TPersistence, bool>> filterExpression)
        {
            return QueryInternal(filterExpression).Any();
        }

        public virtual async Task<bool> AnyAsync(
            Expression<Func<TPersistence, bool>> filterExpression,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(filterExpression).AnyAsync(cancellationToken);
        }

        public virtual async Task<TDomain?> FindAsync(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(queryOptions).SingleOrDefaultAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<List<TDomain>> FindAllAsync(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(queryOptions).ToListAsync<TDomain>(cancellationToken);
        }

        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            int pageNo,
            int pageSize,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(queryOptions);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }

        public virtual async Task<int> CountAsync(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(queryOptions).CountAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default,
            CancellationToken cancellationToken = default)
        {
            return await QueryInternal(queryOptions).AnyAsync(cancellationToken);
        }

        protected virtual IQueryable<TPersistence> QueryInternal(Expression<Func<TPersistence, bool>>? filterExpression, bool ignoreQueryFilters = false)
        {
            var queryable = CreateQuery(ignoreQueryFilters);
            if (filterExpression != null)
            {
                queryable = queryable.Where(filterExpression);
            }
            return queryable;
        }
        protected virtual IQueryable<TResult> QueryInternal<TResult>(
            Expression<Func<TPersistence, bool>> filterExpression,
            Func<IQueryable<TPersistence>, IQueryable<TResult>> queryOptions)
        {
            var queryable = CreateQuery();
            queryable = queryable.Where(filterExpression);
            var result = queryOptions(queryable);
            return result;
        }

        protected virtual IQueryable<TPersistence> QueryInternal(Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions)
        {
            var queryable = CreateQuery();
            if (queryOptions != null)
            {
                queryable = queryOptions(queryable);
            }
            return queryable;
        }
        protected virtual IQueryable<TPersistence> CreateQuery(bool ignoreQueryFilters = false)
        {
            IQueryable<TPersistence> query = GetSet();
            return ignoreQueryFilters ? query.IgnoreQueryFilters() : query;
        }

        protected virtual DbSet<TPersistence> GetSet()
        {
            return _dbContext.Set<TPersistence>();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TProjection>> FindAllProjectToAsync<TProjection>(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default,
            CancellationToken cancellationToken = default)
        {
            var queryable = QueryInternal(queryOptions);
            var projection = queryable.ProjectTo<TProjection>(_mapper.ConfigurationProvider);
            return await projection.ToListAsync(cancellationToken);
        }

        public async Task<IPagedResult<TProjection>> FindAllProjectToAsync<TProjection>(
            int pageNo,
            int pageSize,
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>>? queryOptions = default,
            CancellationToken cancellationToken = default)
        {
            var queryable = QueryInternal(queryOptions);
            var projection = queryable.ProjectTo<TProjection>(_mapper.ConfigurationProvider);
            return await PagedList<TProjection>.CreateAsync(
                projection,
                pageNo,
                pageSize,
                cancellationToken);
        }

        public async Task<TProjection?> FindProjectToAsync<TProjection>(
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> queryOptions,
            CancellationToken cancellationToken = default)
        {
            var queryable = QueryInternal(queryOptions);
            var projection = queryable.ProjectTo<TProjection>(_mapper.ConfigurationProvider);
            return await projection.FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<Dictionary<TKey, TValue>> FindAllToDictionaryAsync<TKey, TValue>(
            Expression<Func<TPersistence, bool>> filterExpression,
            Expression<Func<TPersistence, TKey>> keySelector,
            Expression<Func<TPersistence, TValue>> valueSelector,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TPersistence> query = _dbContext.Set<TPersistence>().Where(filterExpression);
            return await query.ToDictionaryAsync(keySelector.Compile(), valueSelector.Compile(), cancellationToken);
        }

        //custom
        public async Task<List<TPersistence>> FindBySQLRaw(
            string query,
            CancellationToken cancellationToken = default,
            params object[] paramenter)
        {
            var queryable = GetSet();
            return await queryable.FromSqlRaw(query, paramenter).ToListAsync(cancellationToken);
        }
        public Func<IQueryable<TPersistence>, IQueryable<TPersistence>> IQueryableHandlerEqual(object request)
        {
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> handler = query =>
            {
                PropertyInfo[] propeties = request.GetType().GetProperties();
                foreach (PropertyInfo prop in propeties)
                {
                    var propetyValue = prop.GetValue(request, null);
                    if (propetyValue != null)
                    {
                        var domainProperty = typeof(TPersistence).GetProperty(prop.Name);
                        if (domainProperty != null)
                        {
                            var parameter = Expression.Parameter(typeof(TPersistence), "x");
                            var property = Expression.Property(parameter, domainProperty); // Truy cập thuộc tính
                            var constant = Expression.Constant(propetyValue); // Tạo hằng số
                            var equal = Expression.Equal(property, constant); // Tạo biểu thức so sánh bằng
                            var lambda = Expression.Lambda<Func<TPersistence, bool>>(equal, parameter); // Tạo biểu thức lambda
                            query = query.Where(lambda); // Sử dụng biểu thức lambda trong phương thức Where
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return query;
            };
            return handler;
        }
        public Func<IQueryable<TPersistence>, IQueryable<TPersistence>> IQueryableHandlerMultiple(
            object request,
            Func<Expression, Expression, BinaryExpression> expression)
        {
            Func<IQueryable<TPersistence>, IQueryable<TPersistence>> handler = query =>
            {
                PropertyInfo[] propeties = request.GetType().GetProperties();
                foreach (PropertyInfo prop in propeties)
                {
                    var propetyValue = prop.GetValue(request, null);
                    if (propetyValue != null)
                    {
                        var domainProperty = typeof(TPersistence).GetProperty(prop.Name);
                        if (domainProperty != null)
                        {
                            var parameter = Expression.Parameter(typeof(TPersistence), "x");
                            var property = Expression.Property(parameter, domainProperty);
                            var constant = Expression.Constant(propetyValue);
                            var equal = expression(property, constant);
                            var lambda = Expression.Lambda<Func<TPersistence, bool>>(equal, parameter);
                            query = query.Where(lambda);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return query;
            };
            return handler;
        }
        public Expression<Func<TPersistence, bool>>? IExpressionEqual(PropertyInfo pro, object value)
        {
            var domainProperty = typeof(TPersistence).GetProperty(pro.Name);
            if (domainProperty != null)
            {
                var parameter = Expression.Parameter(typeof(TPersistence), "x");
                var property = Expression.Property(parameter, domainProperty);
                var constant = Expression.Constant(value);
                var equal = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<TPersistence, bool>>(equal, parameter);
                return lambda;
            }
            else
            {
                return null;
            }
        }
        // Idea to using this func
        //Func<Expression, Expression, BinaryExpression> equalityExpression =
        //    (property, constant) => Expression.Equal(property, constant);
        //object xx = new object();
        //Expression<Func<UserEntity, bool>>? x = IExpressionMultiple(typeof(UserEntity).GetProperty("Id"), xx, equalityExpression);
        public Expression<Func<TPersistence, bool>>? IExpressionMultiple
            (PropertyInfo pro,
            object value,
            Func<Expression, Expression, BinaryExpression> expression)
        {
            var domainProperty = typeof(TPersistence).GetProperty(pro.Name);
            if (domainProperty != null)
            {
                var parameter = Expression.Parameter(typeof(TPersistence), "x");
                var property = Expression.Property(parameter, domainProperty);
                var constant = Expression.Constant(value);
                var ex = expression(property, constant);
                var lambda = Expression.Lambda<Func<TPersistence, bool>>(ex, parameter);
                return lambda;
            }
            else
            {
                return null;
            }
        }
        public IQueryable<TPersistence> CreateQueryable()
        {
            return GetSet();
        }
        public async Task<TResult?> FindSelectAsync<TResult>(
           Func<IQueryable<TPersistence>, IQueryable<TResult>> selector,
           CancellationToken cancellationToken = default,
           bool ignoreQueryFilters = false)
        {
            return await selector(CreateQuery(ignoreQueryFilters)).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<List<TResult>> FindAllSelectAsync<TResult>(
            Func<IQueryable<TPersistence>, IQueryable<TResult>> selector,
            CancellationToken cancellationToken = default,
            bool ignoreQueryFilters = false)
        {
            return await selector(CreateQuery(ignoreQueryFilters)).ToListAsync(cancellationToken);
        }
        public async Task<IPagedResult<TResult>> FindAllSelectAsync<TResult>(
            int pageNo, int pageSize,
            Func<IQueryable<TPersistence>, IQueryable<TResult>> selector,
            CancellationToken cancellation = default,
            bool ignoreQueryFilters = false)
        {

            return await PagedList<TResult>.CreateAsync(
                selector(CreateQuery(ignoreQueryFilters)),
                pageNo,
                pageSize,
                cancellation
                );
        }
        public virtual async Task<IPagedResult<TDomain>> FindAllAsync(
            IQueryable<TPersistence> filterExpression,
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = QueryInternal(filterExpression);
            return await PagedList<TDomain>.CreateAsync(
                query,
                pageNo,
                pageSize,
                cancellationToken);
        }
        public virtual async Task<TDomain?> FindAsync(
           IQueryable<TPersistence> iqueryable,
           CancellationToken cancellationToken = default)
        {
            return await iqueryable.SingleOrDefaultAsync<TDomain>(cancellationToken);
        }
        protected virtual IQueryable<TPersistence> QueryInternal(IQueryable<TPersistence> queryOptions)
        {
            return queryOptions;
        }
        public async Task<List<T>> QueryRaw<T>(
     string sql, object? param = null, CancellationToken ct = default)
        {
            var connection = _dbContext.Database.GetDbConnection();
            var cmd = new CommandDefinition(sql, param, cancellationToken: ct);
            return (await connection.QueryAsync<T>(cmd)).ToList();
        }

    }
}
