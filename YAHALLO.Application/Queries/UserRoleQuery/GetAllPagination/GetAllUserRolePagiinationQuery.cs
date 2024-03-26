using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.RoleQuery;

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
