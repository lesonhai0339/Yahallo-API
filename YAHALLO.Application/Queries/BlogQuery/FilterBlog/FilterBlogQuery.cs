using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Application.Queries.BlogQuery.FilterBlog
{
    public class FilterBlogQuery: IRequest<PagedResult<BlogDto>>
    {
        public FilterBlogQuery() { }
        public FilterBlogQuery(int pageNumber, int pageSize, string? blogId, string? parentId, bool? like, bool? dislike, bool? viewCount, string? title, CommonStatus? status, BlogEnumType? type)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            BlogId = blogId;
            ParentId = parentId;
            Like = like;
            Dislike = dislike;
            ViewCount = viewCount;
            Title = title;
            Status = status;
            Type = type;
        }

        public int PageNumber { get; set; } 
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
