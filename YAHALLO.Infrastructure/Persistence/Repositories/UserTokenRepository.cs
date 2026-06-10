using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserTokenRepository : RepositoryBase<UserTokenEntity, UserTokenEntity, ApplicationDbContext>, IUserTokenRepository
    {
        public UserTokenRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
