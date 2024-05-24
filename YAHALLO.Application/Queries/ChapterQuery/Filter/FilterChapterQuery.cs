using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.Filter
{
    public class FilterChapterQuery: IRequest<IPagedResult<ChapterDto>>
    {
        public FilterChapterQuery() { }
        public FilterChapterQuery(
            int pagenumber,
            int pagesize,
            int? index,
            string? mangaid,
            string? manganame)
        {
            PageNumber = pagenumber;
            PageNumber = pagesize;
            Index = index;
            MangaId = mangaid;
            MangaName = manganame;  
        }
        public int PageNumber { get;set; }
        public int PageSize { get;set; }

        public string? Id { get; set; }
        public int? Index { get; set; }
        public string? MangaId { get; set; }
        public string? MangaName { get; set; }   
    }
}
