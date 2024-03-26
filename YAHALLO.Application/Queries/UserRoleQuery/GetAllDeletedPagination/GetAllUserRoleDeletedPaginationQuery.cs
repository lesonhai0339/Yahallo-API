using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAllDeletedPagination
{
    public class GetAllUserRoleDeletedPaginationQuery: IRequest<PagedResult<UserRoleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllUserRoleDeletedPaginationQuery() { }
        public GetAllUserRoleDeletedPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
