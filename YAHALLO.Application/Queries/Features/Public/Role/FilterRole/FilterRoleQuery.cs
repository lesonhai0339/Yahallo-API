using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Role;

namespace YAHALLO.Application.Queries.Features.Public.Role.FilterRole
{
    public class FilterRoleQuery: IRequest<PagedResult<RoleDto>>
    {
        public int PageNo { get;set; }
        public int PageSize { get;set; }
        public string? Id { get; set; }
        public int? RoleCode { get; set; }
        public string? RoleName { get; set; }    
    }
}
