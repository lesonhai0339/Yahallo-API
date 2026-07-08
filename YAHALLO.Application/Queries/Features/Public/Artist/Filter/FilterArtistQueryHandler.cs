using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Artist.FilterArtist
{
    public class FilterArtistQueryHandler : IRequestHandler<FilterArtistQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterArtistQueryHandler(IArtistRepository artistRepository, IMapper mapper, IFilters filters)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _filters = filters;
        }

        public async Task<PagedResult<ArtistDto>> Handle(FilterArtistQuery request, CancellationToken cancellationToken)
        {
            var query = _artistRepository.CreateQueryable();

            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) query = query.Where(x => x.Name.Contains(name));

            var artists = await _artistRepository.FindAllAsync(query, request.PageNo, request.PageSize, cancellationToken);
            return artists.MapToPagedResult(x => x.MapToArtistDto(_mapper));
        }
    }
}
