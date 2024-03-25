using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.RoleQuery.FilterRole
{
    public class FilterRoleQuery: IRequest<PagedResult<RoleDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get;set; }
        public string? Id { get; set; }
        public int? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public FilterRoleQuery() { }    
        public FilterRoleQuery(int pageNumber, int pageSize, string? id, int? rolecode, string? rolename)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;
            RoleCode = rolecode;
            RoleName = rolename;
        }
    }
}
