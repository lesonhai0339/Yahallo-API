using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllDeletedPagination
{
    public sealed class GetAllUserDeletedPaginationQuery : IRequest<PagedResult<AdminUserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
