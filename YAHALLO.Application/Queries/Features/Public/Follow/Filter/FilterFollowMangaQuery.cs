using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Follow;

namespace YAHALLO.Application.Queries.Features.Public.Follow.Filter
{
    public class FilterFollowMangaQuery: IRequest<PagedResult<FollowMangaDto>>
    {
        public int PageNo { get;set; }
        public int PageSize { get;set; }
        public string? UserId { get;set; }
        public string? UserName { get; set; }
        public string? MangaId { get;set; }
        public string? MangaName { get ; set; } 
        public FollowSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; }   
    }
}
