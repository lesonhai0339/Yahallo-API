using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAllPagination
{
    public class GetAllUserRolePagiinationQuery : IRequest<PagedResult<UserRoleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllUserRolePagiinationQuery() { }
        public GetAllUserRolePagiinationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
