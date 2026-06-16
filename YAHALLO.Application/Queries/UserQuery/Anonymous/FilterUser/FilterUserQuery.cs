using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser
{
    public class FilterUserQuery : IRequest<PagedResult<UserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id {  get; set; }    
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public UserSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
    }
}
