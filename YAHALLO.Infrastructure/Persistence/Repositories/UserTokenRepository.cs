using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Persistence.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserTokenRepository : RepositoryBase<UserTokenEntity, UserTokenEntity, ApplicationDbContext>, IUserTokenRepository
    {
        public UserTokenRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public override Task<UserTokenEntity?> FindAsync(Expression<Func<UserTokenEntity, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return base.FindAsync(
                filterExpression, 
                x => x.Include(x => x.UserEntity),
                cancellationToken);
        }
    }
}
