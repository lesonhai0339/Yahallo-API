using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetAllDeletedPagination
{
    public class GetAllMangaDeletedPaginationQuery: IRequest<PagedResult<MangaDto>>
    {
        public int PageNumber { get; set; }
        public int PageSizee { get; set; }
        public GetAllMangaDeletedPaginationQuery() { }
        public GetAllMangaDeletedPaginationQuery(int pageNumber, int pageSizee)
        {
            PageNumber = pageNumber;
            PageSizee = pageSizee;
        }
    }
}
