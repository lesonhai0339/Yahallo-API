//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Repositories;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetLatestUpdated
{
    public class GetLatestUpdatedMangaQueryHandler : IRequestHandler<GetLatestUpdatedMangaQuery, PagedResult<MangaSumaryDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMangaQueryRepository _mangaQueryRepository;
        private readonly IMapper _mapper;

        public GetLatestUpdatedMangaQueryHandler(IMangaRepository mangaRepository, IMangaQueryRepository mangaQueryRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mangaQueryRepository = mangaQueryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaSumaryDto>> Handle(GetLatestUpdatedMangaQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaQueryRepository.GetLastUpdateManga(request.PageNumber, request.PageSize, cancellationToken);
            if (mangas == null)
                throw new InvalidDataException("Data empty");
            return new PagedResult<MangaSumaryDto>
            {
                PageCount = mangas.Count,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = mangas.Count,
                Data = mangas
            };
        }
    }
}
