using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Chappter;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.Filter
{
    public sealed class AdminFilterChapterQueryHandler : IRequestHandler<AdminFilterChapterQuery, PagedResult<AdminChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        public AdminFilterChapterQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository; 
        }
        public async Task<PagedResult<AdminChapterDto>> Handle(AdminFilterChapterQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(c => new AdminChapterDto
                    {
                        Id = c.Id,
                        Index = c.Index,
                        Title = c.Title,
                        MangaId = c.MangaId,
                        CreateDate = c.CreateDate,
                        DeleteDate = c.DeleteDate,  
                        MangaName = c.MangaEntity == null ? null : c.MangaEntity.Name,
                        UserId = c.IdUserCreate ?? string.Empty,
                    }),
                cancellation: cancellationToken,
                ignoreQueryFilters: request.IsDeleted
                );
            return chapters.MapToPagedResult(x => x);
        }
        private IQueryable<ChapterEntity> ApplySorting(IQueryable<ChapterEntity> filter, AdminFilterChapterQuery request)
        {
            return request.SortBy switch
            {
                ChapterSortBy.Index => OrderHelper.ApplyOrder(filter, x => x.Index, request.ReverseSort),
                ChapterSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
                ChapterSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities.Select(x => (double?)x.Rating).Average(), request.ReverseSort),
                ChapterSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.TotalCount, request.ReverseSort),
                ChapterSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities == null ? 0 : x.CommentEntities.Count, request.ReverseSort),
                _ => filter
            };
        }
        private IQueryable<ChapterEntity> ApplyFilter(IQueryable<ChapterEntity> query, AdminFilterChapterQuery request)
        {
            if (request.Index != null) query = query.Where(x => x.Index == request.Index);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.MangaEntity!.Name.Contains(request.MangaName));
            if (request.IsDeleted)
                query = query.Where(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue);

            return query;
        }
    }
}
