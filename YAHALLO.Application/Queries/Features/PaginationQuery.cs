using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features
{
    public class PaginationQuery<T>: IPaginatedQuery, IRequest<PagedResult<T>>
    {
        public int PageNo { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
