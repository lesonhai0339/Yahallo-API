//AI generated
using Amazon.Runtime.Internal.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaTagRepository : RepositoryBase<MangaTagEntity, MangaTagEntity, ApplicationDbContext>, IMangaTagRepository
    {
        public MangaTagRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
        public async Task<List<MangaTagEntity>> FindByMangaId(string mangaId, CancellationToken cancellationToken)
        {
            return await FindAllAsync(
                x => x.MangaId == mangaId,
                queryOptions:
                queryOptions => queryOptions.Include(mt => mt.Tag),
                cancellationToken);
        }
    }
     
}
