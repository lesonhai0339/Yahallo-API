using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Repositories
{
    public class UserOldPasswordRepository : RepositoryBase<UserOldPasswordEntity, UserOldPasswordEntity, ApplicationDbContext>, IUserOldPasswordRepository
    {
        public UserOldPasswordRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
