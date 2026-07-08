using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Public.UserRole.Filter
{
    public class FilterUserRoleQuery: IRequest<PagedResult<UserRoleDto>>
    {

        public int PageNo { get; set; } 
        public int PageSize { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public int? RoleCode { get; set; }
    }
}
