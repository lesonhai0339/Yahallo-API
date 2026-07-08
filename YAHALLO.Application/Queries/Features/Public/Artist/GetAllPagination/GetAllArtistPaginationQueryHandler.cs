using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAllPagination
{
    public class GetAllArtistPaginationQueryHandler : IRequestHandler<GetAllArtistPaginationQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        public GetAllArtistPaginationQueryHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ArtistDto>> Handle(GetAllArtistPaginationQuery request, CancellationToken cancellationToken)
        {
            var artists= await _artistRepository.FindAllAsync(request.PageNo, request.PageSize, cancellationToken);
            return artists.MapToPagedResult(x=> x.MapToArtistDto(_mapper));
        }
    }
}
