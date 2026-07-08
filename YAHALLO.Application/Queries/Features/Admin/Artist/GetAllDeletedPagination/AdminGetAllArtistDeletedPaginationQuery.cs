using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.GetAllDeletedPagination
{
    public sealed class GetAllArtistDeletedPaginationQuery: IRequest<PagedResult<AdminArtistDto>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
