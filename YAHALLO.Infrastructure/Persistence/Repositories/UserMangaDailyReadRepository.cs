using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserMangaDailyReadRepository : RepositoryBase<UserMangaDailyReadEntity, UserMangaDailyReadEntity, ApplicationDbContext>, IUserMangaDailyReadRepository
    {
        public UserMangaDailyReadRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
