using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.MangaRating;

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterRatingQuery: IRequest<PagedResult<RatingDto>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public string? MangaId { get;set; }
        public string? MangaName { get; set; }
        public string? ChapterId { get; set; }  
        public string? ToUserId { get; set; }   
        public string? UserId { get;set; }
        public string? UserName { get; set; } 
        public MangaRatingSortBy SortBy { get; set; }
        public bool ReverserSort { get; set; }   
    }
}
