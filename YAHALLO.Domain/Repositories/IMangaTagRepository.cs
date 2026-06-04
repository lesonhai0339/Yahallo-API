//AI generated
using YAHALLO.Domain.Entities;

namespace YAHALLO.Domain.Repositories
{
    public interface IMangaTagRepository : IEFRepository<MangaTagEntity, MangaTagEntity>
    {
        Task<List<MangaTagEntity>> FindByMangaId(string mangaId, CancellationToken cancellationToken);
    }
}
