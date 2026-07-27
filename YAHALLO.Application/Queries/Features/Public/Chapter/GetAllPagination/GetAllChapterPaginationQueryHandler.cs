using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetAllPagination
{
    public class GetAllChapterPaginationQueryHandler : IRequestHandler<GetAllChapterPaginationQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        public GetAllChapterPaginationQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<PagedResult<ChapterDto>> Handle(GetAllChapterPaginationQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository
               .FindAllSelectAsync(
                   pageNo: request.PageNo,
                   pageSize: request.PageSize,
                   selector: q => q
                   .OrderBy(x => x.Index).ThenBy(x=> x.SubIndex)
                   .Select(x => new ChapterDto
                   {
                       Id = x.Id,
                       Index = x.Index,
                       MangaId = x.MangaId!,
                       MangaName = x.MangaEntity == null ? null : x.MangaEntity.Name,
                       Title = x.Title,
                       CreateDate = x.CreateDate,
                       SubIndex = x.SubIndex,
                   }),
                   cancellation: cancellationToken);

            return chapters.MapToPagedResult(x => x);
        }
    }
}
