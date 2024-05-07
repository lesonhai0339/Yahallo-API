using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.ChapterQuery.FilterChapter
{
    public class FilterChapterQuery: IRequest<PagedResult<ChapterDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id { get;set; }
        public int? Index { get; set; }
        public string? MangaId { get; set; }
        public string? MangaName { get;set; }
        public FilterChapterQuery() { }
        public FilterChapterQuery(
            int pageNumber, 
            int pageSize, 
            string? id, 
            int? index, 
            string? mangaId, 
            string? mangaName)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;
            Index = index;
            MangaId = mangaId;
            MangaName = mangaName;
        }
    }
}
