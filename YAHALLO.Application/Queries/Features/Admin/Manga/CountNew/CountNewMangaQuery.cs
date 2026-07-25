using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.CountNew
{
    public class CountNewMangaQuery: IRequest<PagedResult<CountNewMangaQueryResult>>
    {
        public int PageNo { get; init; }
        public int PageSize { get; init; }  
        public DateTimeOffset From { get; init; }
        public DateTimeOffset To { get; init; }   
        public MangaGroupBy GroupBy { get; init; } = MangaGroupBy.Day;  
    }
    public enum MangaGroupBy
    {
        Day, 
        Month,
        Year
    }
    public record CountNewMangaQueryResult
    {
        public int Day { get; set; }
        public int Month { get; set; }  
        public int Year { get; set; }  
        public int Count { get; set; }
    }
}
