using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeletedPagination
{
    public sealed class AdminGetAllArtistDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllArtistDeletedPaginationQuery, PagedResult<AdminArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        public AdminGetAllArtistDeletedPaginationQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<PagedResult<AdminArtistDto>> Handle(AdminGetAllArtistDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.FindAllSelectAsync(
            pageNo: request.PageNo,
            pageSize: request.PageSize,
             selector:   x => x
               .Where(a => !string.IsNullOrEmpty(a.IdUserDelete) && a.DeleteDate.HasValue)
               .Select(t => new AdminArtistDto
               {
                   Id = t.Id,
                   Name = t.Name,
                   Birth = t.Birth,
                   Country = t.Countries.GetDescription(),
                   Depscription = t.Depscription,
                   LifeStatus = t.LifeStatus.GetDescription()
               }),
            cancellation: cancellationToken,
            ignoreQueryFilters: true);

            return artists.MapToPagedResult(x => x);
        }
    }
}
