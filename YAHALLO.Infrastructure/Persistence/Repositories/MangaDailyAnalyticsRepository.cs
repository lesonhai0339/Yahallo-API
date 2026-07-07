using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaDaily;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaDailyAnalyticsRepository : RepositoryBase<MangaDailyAnalyticsEntity, MangaDailyAnalyticsEntity, ApplicationDbContext>, IMangaDailyAnalyticsRepository
    {
        public MangaDailyAnalyticsRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task Increment(string mangaId, MangaDailyType type, CancellationToken cancellation)
        {
            var today = DateTime.UtcNow.Date;

            var daily = await FindAsync(x => x.MangaId == mangaId && x.Date == today, cancellation);
            if(daily == null)
            {
                var mangaDaily = new MangaDailyAnalyticsEntity
                {
                    MangaId = mangaId,
                    Date = today,
                    ViewCount = type == MangaDailyType.View ? 1 : 0,
                    FollowerCount = type == MangaDailyType.Follow ? 1 : 0,
                    CommentCount = type == MangaDailyType.Comment ? 1 : 0,
                };
                Add(mangaDaily);
            }
            else
            {
                daily.ViewCount += type == MangaDailyType.View ? 1 : 0;
                daily.FollowerCount += type == MangaDailyType.Follow ? 1 : 0;
                daily.CommentCount += type == MangaDailyType.Comment ? 1 : 0;

                Update(daily);
            }
        }
        public async Task DecrementFollower(string mangaId, CancellationToken cancellation)
        {
            var today = DateTime.UtcNow.Date;

            var daily = await FindAsync(x => x.MangaId == mangaId && x.CreateDate == today, cancellation);
            if (daily == null)
                throw new NotFoundException("Manga daily analytics not found for today.");

            daily.FollowerCount -= 1;

            Update(daily);
        }
    }
}
