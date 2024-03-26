using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserRoleQuery.FilterUserRole
{
    public class FilterUserRoleQuery: IRequest<PagedResult<UserRoleDto>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public int? RoleCode { get; set; }
    }
}
