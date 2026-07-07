using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Author.GetAllDeletedPagination
{
    public sealed class GetAllAuthorDeletedPaginationQuery: IRequest<PagedResult<AdminAuthorDto>>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
