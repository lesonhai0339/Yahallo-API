//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserMangaViewRepository : RepositoryBase<UserMangaViewEntity, UserMangaViewEntity, ApplicationDbContext>, IUserMangaViewRepository
    {
        public UserMangaViewRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
