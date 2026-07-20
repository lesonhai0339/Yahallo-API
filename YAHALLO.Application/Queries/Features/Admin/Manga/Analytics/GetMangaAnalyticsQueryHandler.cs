using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Domain.Enums.MangaDaily;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.Analytics
{
    public class GetMangaAnalyticsQueryHandler : IRequestHandler<GetMangaAnalyticsQuery, GetMangaAnalyticsResult>
    {
        private readonly IMangaDailyAnalyticsRepository _mangaDailyRepository;
        private readonly IMangaRepository _mangaRepository;
        public GetMangaAnalyticsQueryHandler(
            IMangaDailyAnalyticsRepository mangaDailyRepository, 
            IMangaRepository mangaRepository
            )
        {
            _mangaDailyRepository = mangaDailyRepository;
            _mangaRepository = mangaRepository;
        }
        public async Task<GetMangaAnalyticsResult> Handle(GetMangaAnalyticsQuery request, CancellationToken cancellationToken)
        {
            var startDate = request.From.Date;
            var endDate = request.To.Date;

            var startMonth = new DateTime(request.From.Year, request.From.Month, 1);
            var endMonth = new DateTime(request.To.Year, request.To.AddMonths(1).Month, 1);

            var startYear = new DateTime(request.From.Year, 1,  1);
            var endYear = new DateTime(request.To.AddYears(1).Year, 1, 1);  

            var result = request.FilterBy switch
            {
                MangaDailyFilterBy.Day => await _mangaDailyRepository.FindAllSelectAsync(
                selector: x => x
                .Where(d => d.MangaId == request.MangaId
                    && d.CreateDate >= request.From
                    && d.CreateDate < request.To.AddDays(1))
                .GroupBy(x => x.CreateDate.Date)
                .Select(g => new MangaAnalytics
                {
                    MangaId = request.MangaId,
                    TotalFollower = g.Sum(i => i.FollowerCount),
                    TotalComment = g.Sum(i => i.CommentCount),
                    TotalView = g.Sum(i => i.ViewCount),
                    Day = g.Key.Day,
                    Month = g.Key.Month,
                    Year = g.Key.Year
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day),
                cancellationToken),


                MangaDailyFilterBy.Month => await _mangaDailyRepository.FindAllSelectAsync(
                selector: x => x
                .Where(d => d.MangaId == request.MangaId
                    && d.CreateDate >= request.From
                    && d.CreateDate < request.To.AddDays(1))
                .GroupBy(x => new { x.CreateDate.Month, x.CreateDate.Year })
                .Select(g => new MangaAnalytics
                {
                    MangaId = request.MangaId,
                    TotalFollower = g.Sum(i => i.FollowerCount),
                    TotalComment = g.Sum(i => i.CommentCount),
                    TotalView = g.Sum(i => i.ViewCount),
                    Day = 1,
                    Month = g.Key.Month,
                    Year = g.Key.Year
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month),
                cancellationToken) ,


                MangaDailyFilterBy.Year => await _mangaDailyRepository.FindAllSelectAsync(
                selector: x => x
                .Where(d => d.MangaId == request.MangaId
                    && d.CreateDate >= request.From
                    && d.CreateDate < request.To.AddDays(1))
                .GroupBy(x => x.CreateDate.Year)
                .Select(g => new MangaAnalytics
                {
                    MangaId = request.MangaId,
                    TotalFollower = g.Sum(i => i.FollowerCount),
                    TotalComment = g.Sum(i => i.CommentCount),
                    TotalView = g.Sum(i => i.ViewCount),
                    Day = 1,
                    Month = 1,
                    Year = g.Key
                })
                .OrderBy(x => x.Year),
                cancellationToken),

                _ => throw new BadRequestException($"FilterBy {request.FilterBy} không hợp lệ, chỉ chấp nhận các giá trị: 'day', 'month', 'year'")
            };
            var sumary = await _mangaRepository.FindSelectAsync(x => x
                .Where(m => m.Id == request.MangaId)
                .Select(t => new
                {
                    totalView = t.ViewCount == null ? 0 : t.ViewCount.TotalCount,
                    totalComment = t.CommentEntities.Count(),
                    totalFollowing = t.FollowEntities.Count(),
                    totalChapter = t.ChaptersEntities.Count()
                }),
                cancellationToken);
            return new GetMangaAnalyticsResult
            {
                TotalView = sumary?.totalView,
                TotalComment = sumary?.totalComment, 
                TotalFollowing = sumary?.totalFollowing, 
                TotalChapter = sumary?.totalChapter,
                MangaAnalytics = result 
            };
        }
    }
}
