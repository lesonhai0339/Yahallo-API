//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetLatestUpdated
{
    public class GetLatestUpdatedMangaQueryHandler : IRequestHandler<GetLatestUpdatedMangaQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;

        public GetLatestUpdatedMangaQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaDto>> Handle(GetLatestUpdatedMangaQuery request, CancellationToken cancellationToken)
        {
            var query = _mangaRepository.CreateQueryable();
            query = query
                .Where(x => string.IsNullOrEmpty(x.IdUserDelete))
                .OrderByDescending(x => x.UpdateDate ?? x.CreateDate);

            var paged = await _mangaRepository.FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            return paged.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
