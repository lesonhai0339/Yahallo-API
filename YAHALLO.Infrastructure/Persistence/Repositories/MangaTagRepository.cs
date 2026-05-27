//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaTagRepository : RepositoryBase<MangaTagEntity, MangaTagEntity, ApplicationDbContext>, IMangaTagRepository
    {
        public MangaTagRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
