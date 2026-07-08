using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.Features.Public.User.Filter
{
    public class FilterUserQuery : IRequest<PagedResult<UserDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? Id {  get; set; }    
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public UserSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
    }
}
