using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeletedPagination
{
    public sealed class GetAllDeletedChapterPaginationQueryHandler : IRequestHandler<GetAllDeletedChapterPaginationQuery, PagedResult<AdminChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        public GetAllDeletedChapterPaginationQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<PagedResult<AdminChapterDto>> Handle(GetAllDeletedChapterPaginationQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository.FindAllSelectAsync(
            pageNo: request.PageNumber,
            pageSize: request.PageSize, 
            selector: x => x
               .Where(c => !string.IsNullOrEmpty(c.IdUserDelete) && c.DeleteDate.HasValue)
               .Select(t => new AdminChapterDto
               {
                   Id = t.Id,
                   CreateDate = t.CreateDate,
                   Index = t.Index,
                   Title = t.Title,
                   MangaId = t.MangaId,
                   MangaName = t.MangaEntity == null ? null : t.MangaEntity.Name,
               }),
           cancellation: cancellationToken,
           ignoreQueryFilters: true);
            return chapters.MapToPagedResult(x => x);
        }
    }
}
