using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Chappter;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.Filter
{
    public class FilterChapterQueryHandler : IRequestHandler<FilterChapterQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        public FilterChapterQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }
        public async Task<PagedResult<ChapterDto>> Handle(FilterChapterQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository
                .FindAllSelectAsync(
                    pageNo: request.PageNo, 
                    pageSize: request.PageSize,
                    selector: q =>
                    ApplySorting(ApplyFilter(q, request), request)
                    .Select(x => new ChapterDto
                    {
                        Id = x.Id,
                        Index = x.Index,
                        MangaId = x.MangaId!,
                        MangaName = x.MangaEntity == null ? null :  x.MangaEntity.Name,
                        Title = x.Title,
                        CreateDate = x.CreateDate,
                        SubIndex = x.SubIndex
                    }),
                    cancellation: cancellationToken);

            return chapters.MapToPagedResult(x => x);
        }
        private IQueryable<ChapterEntity> ApplySorting(IQueryable<ChapterEntity> filter, FilterChapterQuery request)
        {
            return request.SortBy switch
            {
                ChapterSortBy.Index => OrderHelper.ApplyOrder(filter, x => x.Index, request.ReverseSort).ThenBy(x => x.SubIndex),
                ChapterSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
                ChapterSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities.Select(x => (double?)x.Rating).Average(), request.ReverseSort),
                ChapterSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.TotalCount, request.ReverseSort),
                ChapterSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities == null ? 0 : x.CommentEntities.Count, request.ReverseSort),
                _ => filter
            };
        }
        private IQueryable<ChapterEntity> ApplyFilter(IQueryable<ChapterEntity> query, FilterChapterQuery request)
        {
            if (request.Index != null) query = query.Where(x => x.Index == request.Index);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.MangaEntity!.Name.Contains(request.MangaName));
            return query;
        }
    }
}
