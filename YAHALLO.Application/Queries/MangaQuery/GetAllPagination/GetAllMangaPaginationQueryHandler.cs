using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetAllPagination
{
    public class GetAllMangaPaginationQueryHandler : IRequestHandler<GetAllMangaPaginationQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public GetAllMangaPaginationQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaDto>> Handle(GetAllMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var listMangaExists = await _mangaRepository
                .FindAllAsync(
                filterExpression: x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, 
                pageNo: request.PageNumber, 
                pageSize: request.PageSize,
                queryOptions: x => x.OrderByDescending(m => m.LastChapterUpdate),
                cancellationToken: cancellationToken);
            if(listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ manga nào");
            }
            return new PagedResult<MangaDto>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = listMangaExists.TotalCount,
                PageCount = listMangaExists.PageCount,
                Data = listMangaExists.Select(m =>
                {
                    var manga = m.MapFullToMangaDto(_mapper);
                    manga.LastestChapter = new ChapterDto
                    {
                        Id = m.LastChapterId ?? "",
                        Index = m.LastChapterIndex,
                        CreateDate = m.LastChapterUpdate,
                        MangaId = m.Id,
                        MangaName = m.Name,
                    };
                    return manga;
                })
            };
        }
    }
}
