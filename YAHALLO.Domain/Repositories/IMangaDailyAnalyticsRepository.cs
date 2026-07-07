using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaDaily;

namespace YAHALLO.Domain.Repositories
{
    public interface IMangaDailyAnalyticsRepository : IEFRepository<MangaDailyAnalyticsEntity, MangaDailyAnalyticsEntity>, IAnalyticsEntity
    {
        Task Increment(string mangaId, MangaDailyType type, CancellationToken cancellation);
        Task DecrementFollower(string mangaId, CancellationToken cancellation);
    }
}
