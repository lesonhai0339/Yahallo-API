using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeletedPagination
{
    public sealed class GetAllDeletedFollowMangaPaginationQuery: IRequest<PagedResult<AdminFollowDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
