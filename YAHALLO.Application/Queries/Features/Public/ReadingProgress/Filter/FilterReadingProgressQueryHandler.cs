using MediatR;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.ReadingProgress;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUserPagination
{
    public class FilterReadingProgressQueryHandler : IRequestHandler<FilterReadingProgressQuery, PagedResult<ReadingProgressDto>>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IReadingProgressRepository _readingProgressRepository; 
        public FilterReadingProgressQueryHandler(ICurrentUserService currentUserService, IReadingProgressRepository readingProgressRepository)
        {
            _currentUser = currentUserService;
            _readingProgressRepository = readingProgressRepository;
        }

        public async Task<PagedResult<ReadingProgressDto>> Handle(FilterReadingProgressQuery request, CancellationToken cancellationToken)
        {
            var readingProgresses = await _readingProgressRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                    ApplyGroupSorting(ApplyFilter(q, request).GroupBy(r => r.MangaId), request)
                    .Select(g => g
                        .OrderByDescending(r => r.LastReadAt)
                        .Select(r => new ReadingProgressDto
                        {
                            MangaId = r.MangaId,
                            MangaName = r.Manga.Name,
                            MangaThumbnail = r.Manga.MangaThumbnail,
                            ChapterId = r.ChapterId,
                            ChapterTitle = r.Chapter.Title,
                            ChapterIndex = r.Chapter.Index,
                            LastPage = r.LastPage,
                            LastReadAt = r.LastReadAt,
                        })
                .First()),
                cancellation: cancellationToken);

            return readingProgresses.MapToPagedResult(x => x);
        }
        private IQueryable<IGrouping<string, ReadingProgressEntity>> ApplyGroupSorting(
            IQueryable<IGrouping<string, ReadingProgressEntity>> grouped,
            FilterReadingProgressQuery request)
        {
            return request.SortBy switch
            {
                ReadingProgressSortBy.LastReadAt => request.ReverseSort
                    ? grouped.OrderBy(g => g.Max(r => r.LastReadAt))
                    : grouped.OrderByDescending(g => g.Max(r => r.LastReadAt)),
                _ => grouped.OrderByDescending(g => g.Max(r => r.LastReadAt))
            };
        }
        private IQueryable<ReadingProgressEntity> ApplyFilter(IQueryable<ReadingProgressEntity> query, FilterReadingProgressQuery request)
        {            
            query = query.Where(x => x.UserId == _currentUser.UserId);

            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            return query;
        }
    }
}
