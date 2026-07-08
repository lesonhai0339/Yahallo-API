using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAllPagination
{
    public class GetAllArtistPaginationQueryHandler : IRequestHandler<GetAllArtistPaginationQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        public GetAllArtistPaginationQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<PagedResult<ArtistDto>> Handle(GetAllArtistPaginationQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Select(x => new ArtistDto
                    {
                        Id = x.Id,  
                        Name = x.Name,
                        Depscription = x.Depscription,
                        Birth = x.Birth,
                        Countries = x.Countries,
                        LifeStatus = x.LifeStatus   
                    }),
                cancellation: cancellationToken);

            return artists.MapToPagedResult(x => x);
        }
    }
}
