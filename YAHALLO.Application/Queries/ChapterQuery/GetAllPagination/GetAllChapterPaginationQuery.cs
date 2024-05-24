using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllPagination
{
    public class GetAllChapterPaginationQuery: IRequest<PagedResult<ChapterDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get; set; }
<<<<<<< HEAD
        public GetAllChapterPaginationQuery(int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
=======
        public GetAllChapterPaginationQuery() { }
        public GetAllChapterPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
>>>>>>> master
        }
    }
}
