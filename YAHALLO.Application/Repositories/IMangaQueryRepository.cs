using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery;

namespace YAHALLO.Application.Repositories
{
    public interface IMangaQueryRepository
    {
        Task<MangaDetailDto?> GetMangaDetail(string mangaId, CancellationToken token);
    }
}
