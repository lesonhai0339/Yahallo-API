using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.BlogQuery.GetAllPagination
{
    public class GetAllBlogPaginationQuery: IRequest<PagedResult<BlogDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllBlogPaginationQuery() { }  
        public GetAllBlogPaginationQuery(int pageNumber, int pageSize) 
        {
            PageNumber = pageNumber;
            PageSize = pageSize;    
        }
    }
}
