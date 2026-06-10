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
    }
}
