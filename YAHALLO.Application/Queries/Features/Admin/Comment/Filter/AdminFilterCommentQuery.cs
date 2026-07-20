using YAHALLO.Domain.Enums.Comment;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.Filter
{
    public sealed class AdminFilterCommentQuery: PaginationQuery<AdminCommentDto>
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? ParentId { get; set; }
        public DateTimeOffset? From { get; set;  }
        public DateTimeOffset? To { get; set; }
        public CommentSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
