using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetReadHistoryByUser;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetUserReadingHistory
{
    public class GetUserReadingHistoryQueryHandler : IRequestHandler<GetUserReadingHistoryQuery, PagedResult<GetUserReadingHistoryResult>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IReadingProgressRepository _readingProgressRepository;
        private readonly IChapterImageRepository _chapterImageRepository;
        public GetUserReadingHistoryQueryHandler(
            ICurrentUserService currentUserService, 
            IReadingProgressRepository readingProgressRepository,
            IChapterImageRepository chapterImageRepository
            )
        {
            _currentUserService = currentUserService;
            _readingProgressRepository = readingProgressRepository;
            _chapterImageRepository = chapterImageRepository;
        }

        public async Task<PagedResult<GetUserReadingHistoryResult>> Handle(GetUserReadingHistoryQuery request, CancellationToken cancellationToken)
        {
            var results = await _readingProgressRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q => q
                    .Where(x => x.UserId == _currentUserService.UserId)
                    .GroupBy(x => new { x.MangaId, MangaName = x.Manga.Name, x.Manga.MangaThumbnail })
                    .OrderByDescending(g => g.Max(x => x.LastReadAt)) 
                    .Select(r => new GetUserReadingHistoryResult
                    {
                        MangaId = r.Key.MangaId,
                        MangaName = r.Key.MangaName,
                        MangaThumbnail = r.Key.MangaThumbnail,
                        Chapters = r
                            .OrderByDescending(c => c.LastReadAt)
                            .Take(5)
                            .Select(c => new ChapterReadingProgress
                            {
                                ChapterId = c.ChapterId,
                                Index = c.Chapter.Index,
                                SubIndex = c.Chapter.SubIndex,
                                LastReadAt = c.LastReadAt,
                                LastReadPage  = c.LastPage,
                            })
                            .ToArray()
                    }),
                cancellation: cancellationToken
                );

            var chapters = results.SelectMany(r => r.Chapters).ToList();
            if (chapters.Count > 0)
            {
                var chapterIds = chapters.Select(c => c.ChapterId).Distinct().ToList();

                var counts = await _chapterImageRepository.FindAllSelectAsync(
                    q => q.Where(i => chapterIds.Contains(i.ChapterId))
                          .GroupBy(i => i.ChapterId)
                          .Select(g => new { ChapterId = g.Key, Total = g.Count() }),
                    cancellationToken);

                var map = counts.ToDictionary(x => x.ChapterId, x => x.Total);

                foreach (var c in chapters)
                    c.TotalPage = map.TryGetValue(c.ChapterId, out var total) ? total : 0;
            }

            return results.ToPagedResult();
        }
    }
}
