using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser
{
    public class FilterUserQuery : IRequest<PagedResult<UserDto>>
    {
        public FilterUserQuery() { }
        public FilterUserQuery(
            int pageNumber,
            int pageSize,
            string? id,
            string? name,
            string? email,
            string? phone)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id {  get; set; }    
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
