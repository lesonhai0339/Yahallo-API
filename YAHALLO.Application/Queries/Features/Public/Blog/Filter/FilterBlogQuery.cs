using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Application.Queries.Features.Public.Blog.Filter
{
    public class FilterBlogQuery: IRequest<PagedResult<BlogDto>>
    {

        public int PageNo { get; set; } 
        public int PageSize { get; set; }
        public string? BlogId { get; set; }  
        public string? ParentId { get;set; }

        /// <summary>
        /// True: like count min -> max
        /// False: like count max-> min
        /// </summary>
        public bool? Like { get;set; }
        /// <summary>
        /// True: like count min -> max
        /// False: like count max-> min
        /// </summary>
        public bool? Dislike { get;set; }
        /// <summary>
        /// True: like count min -> max
        /// False: like count max-> min
        /// </summary>
        public bool? ViewCount { get; set; }
        public string? Title { get; set; }
        public CommonStatus? Status { get; set; }
        public BlogEnumType? Type { get; set; }
    }
}
