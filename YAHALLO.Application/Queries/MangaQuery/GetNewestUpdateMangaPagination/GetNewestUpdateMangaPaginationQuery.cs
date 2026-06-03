using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetNewestUpdateMangaPagination
{
    public class GetNewestUpdateMangaPaginationQuery : IRequest<PagedResult<MangaDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetNewestUpdateMangaPaginationQuery() { }
        public GetNewestUpdateMangaPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
