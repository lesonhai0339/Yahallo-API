using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.ThreadEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Blog.Filter
{
    public class AdminBlogFilterQuery: PaginationQuery<AdminBlogDto>
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public CommonStatus? Status { get; set; }
        public BlogEnumType? Type { get; set; }
        public AdminFilterBlogSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
    public enum AdminFilterBlogSortBy
    {
        Like,
        DisLike
    }
}
