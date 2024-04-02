using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetAllPagination
{
    public class GetAllMangaPaginationQuery: IRequest<PagedResult<MangaDto>>
    {
        public int PageNumber { get; set; }
        public int PageSizee { get;set; }
        public GetAllMangaPaginationQuery() { } 
        public GetAllMangaPaginationQuery(int pageNumber, int pageSizee)
        {
            PageNumber = pageNumber;
            PageSizee = pageSizee;
        }   
    }
}
