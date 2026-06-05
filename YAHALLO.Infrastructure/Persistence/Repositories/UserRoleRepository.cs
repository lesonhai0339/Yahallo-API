using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity, UserRoleEntity, ApplicationDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public override Task<List<UserRoleEntity>> FindAllAsync(Expression<Func<UserRoleEntity, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return base.FindAllAsync(filterExpression,
                x => x.Include(x => x.RoleEntity)
                    .Include(x => x.UserEntity),
                cancellationToken);
        }
        public override Task<IPagedResult<UserRoleEntity>> FindAllAsync(IQueryable<UserRoleEntity> filterExpression, int pageNo, int pageSize, CancellationToken cancellationToken = default)
        {
            return base.FindAllAsync(
                filterExpression: filterExpression
                .Include(x => x.RoleEntity)
                .Include(x => x.UserEntity), 
                pageNo: pageNo, 
                pageSize: pageSize, 
                cancellationToken);
        }
    }
}
