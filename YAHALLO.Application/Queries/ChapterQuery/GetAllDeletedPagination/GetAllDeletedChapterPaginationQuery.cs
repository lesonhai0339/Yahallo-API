using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllDeletedPagination
{
    public class GetAllDeletedChapterPaginationQuery: IRequest<PagedResult<ChapterDto>>
    {
<<<<<<< HEAD
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllDeletedChapterPaginationQuery(int pagenumber,
            int pagesize)
        {
            PageNumber = pagenumber;
            PageSize = pagesize;
=======
        public int PageNumber { get;set; }
        public int PageSize { get; set; }
        public GetAllDeletedChapterPaginationQuery() { }
        public GetAllDeletedChapterPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;    
>>>>>>> master
        }
    }
}
