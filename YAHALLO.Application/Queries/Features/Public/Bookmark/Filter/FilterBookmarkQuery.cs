//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.BookmarkEnums;

namespace YAHALLO.Application.Queries.Features.Public.Bookmark.Filter
{
    public class FilterBookmarkQuery : IRequest<PagedResult<BookmarkDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        /// <summary>
        /// Chỉ mod/admin mới lọc được dấu trang của người khác. Người thường
        /// truyền gì vào đây cũng bị handler ép về chính mình.
        /// </summary>
        public string? UserId { get; set; }

        public string? Name { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? BlogId { get; set; }

        public BookmarkSortBy SortBy { get; set; }
        public bool ReverseSort { get; set; }
    }
}
