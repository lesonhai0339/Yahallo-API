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

namespace YAHALLO.Application.Queries.MangaQuery.Analytics
{
    public class GetMangaAnalyticsQueryHandler : IRequestHandler<GetMangaAnalyticsQuery, GetMangaAnalyticsResult>
    {
        private readonly IMangaDailyAnalyticsRepository _mangaDailyRepository;
        private readonly IChapterRepository _chapterRepository;
        public GetMangaAnalyticsQueryHandler(IMangaDailyAnalyticsRepository mangaDailyRepository, IChapterRepository chapterRepository)
        {
            _mangaDailyRepository = mangaDailyRepository;
            _chapterRepository = chapterRepository;
        }
        public async Task<GetMangaAnalyticsResult> Handle(GetMangaAnalyticsQuery request, CancellationToken cancellationToken)
        {

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
                .GroupBy(x => new { Month = x.CreateDate.Month, Year = x.CreateDate.Year })
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
            var chapterCount = await _chapterRepository.CountAsync(x => x.MangaId == request.MangaId, cancellationToken);  

            return new GetMangaAnalyticsResult
            {
                TotalChapter = chapterCount,
                MangaAnalytics = result 
            };
        }
    }
}
