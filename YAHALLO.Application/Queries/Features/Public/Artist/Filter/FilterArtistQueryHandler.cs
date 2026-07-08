using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Artist.FilterArtist
{
    public class FilterArtistQueryHandler : IRequestHandler<FilterArtistQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        public FilterArtistQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<PagedResult<ArtistDto>> Handle(FilterArtistQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q => 
                    ApplyFilter(q, request)
                    .Select(x => new ArtistDto
                    {
                        Id = x.Id,  
                        Name = x.Name,
                        Depscription = x.Depscription,
                        Birth = x.Birth,
                        Countries = x.Countries,
                        LifeStatus = x.LifeStatus
                    }),
                cancellationToken
                );

            return artists.MapToPagedResult(x => x);
        }
        private IQueryable<ArtistEntity> ApplyFilter(IQueryable<ArtistEntity> query, FilterArtistQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) 
            {
                query = query.Where(x => x.Name.Contains(name));
            }
            return query;
        } 

    }
}
