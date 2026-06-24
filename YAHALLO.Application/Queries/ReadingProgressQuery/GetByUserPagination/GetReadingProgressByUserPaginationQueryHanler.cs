using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.ReadingProgress;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ReadingProgressQuery.GetByUserPagination
{
    public class GetReadingProgressByUserPaginationQueryHanler : IRequestHandler<GetReadingProgressByUserPaginationQuery, PagedResult<ReadingProgressDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IReadingProgressRepository _readingProgressRepository; 
        public GetReadingProgressByUserPaginationQueryHanler(ICurrentUserService currentUserService, IReadingProgressRepository readingProgressRepository)
        {
            _currentUserService = currentUserService;
            _readingProgressRepository = readingProgressRepository;
        }

        public async Task<PagedResult<ReadingProgressDto>> Handle(GetReadingProgressByUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUserService.AuthorizeAsync(Policies.ModOrAdmin);
            request.UserId = (isStaff && !string.IsNullOrEmpty(request.UserId))
                ? request.UserId
                : _currentUserService.UserId;

            var query = _readingProgressRepository.CreateQueryable();
            query = ApplyFilter(query, request);

            var grouped = query.GroupBy(r => r.MangaId);
            grouped = ApplyGroupSorting(grouped, request);

            var readingProgresses = await _readingProgressRepository.FindAllSelectAsync(
                pageNo: request.PageNumber,
                pageSize: request.PageSize,
                selector: _ => grouped
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
            if (!readingProgresses.Any())
                throw new NotFoundException("No reading progress found!");

            return readingProgresses.MapToPagedResult(x => x);
        }
        private IQueryable<IGrouping<string, ReadingProgressEntity>> ApplyGroupSorting(
    IQueryable<IGrouping<string, ReadingProgressEntity>> grouped,
    GetReadingProgressByUserPaginationQuery request)
        {
            return request.SortBy switch
            {
                ReadingProgressSortBy.LastReadAt => request.ReverseSort
                    ? grouped.OrderBy(g => g.Max(r => r.LastReadAt))
                    : grouped.OrderByDescending(g => g.Max(r => r.LastReadAt)),
                _ => grouped
            };
        }
        private IQueryable<ReadingProgressEntity> ApplyFilter(IQueryable<ReadingProgressEntity> query, GetReadingProgressByUserPaginationQuery request)
        {
            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId == request.UserId);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            return query;
        }
    }
}
