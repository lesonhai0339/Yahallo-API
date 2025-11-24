using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Persistence.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRoleEntity, UserRoleEntity, ApplicationDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
