using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.BlogQuery.GetAllDeletedPagination
{
    public class GetAllBlogDeletedPaginationQuery: IRequest<PagedResult<BlogDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize {  get; set; }  
        public GetAllBlogDeletedPaginationQuery() { }
        public GetAllBlogDeletedPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;    
            PageSize = pageSize;
        }
    }
}
