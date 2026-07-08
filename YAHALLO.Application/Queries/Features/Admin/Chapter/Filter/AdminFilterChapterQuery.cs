using YAHALLO.Domain.Enums.Chappter;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.Filter
{
    public sealed class AdminFilterChapterQuery : PaginationQuery<AdminChapterDto>
    {
        public int? Index { get; set; }
        public string? MangaId { get; set; }
        public string? MangaName { get; set; }
        public ChapterSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
        public bool IsDeleted { get; internal set; }
    }
}
