using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllPagination
{
    public class GetAllRolePaginationQuery: IRequest<PagedResult<RoleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }   
        public GetAllRolePaginationQuery() { }
        public GetAllRolePaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
