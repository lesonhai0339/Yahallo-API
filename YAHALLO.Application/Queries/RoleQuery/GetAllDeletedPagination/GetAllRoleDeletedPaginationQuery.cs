using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllDeletedPagination
{
    public class GetAllRoleDeletedPaginationQuery: IRequest<PagedResult<RoleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllRoleDeletedPaginationQuery() { }
        public GetAllRoleDeletedPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
