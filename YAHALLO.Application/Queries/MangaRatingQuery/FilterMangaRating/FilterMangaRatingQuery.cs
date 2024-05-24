using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterMangaRatingQuery: IRequest<PagedResult<MangaRatingDto>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public string? MangaId { get;set; }
        public string? MangaName { get; set; }
        public string? UserId { get;set; }
        public string? UserName { get; set; }
        public FilterMangaRatingQuery() { }
        public FilterMangaRatingQuery(int pageNumber, int pageSize, string? mangaId, string? mangaName, string? userId, string? userName)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            MangaId = mangaId;
            MangaName = mangaName;
            UserId = userId;
            UserName = userName;
        }   
    }
}
