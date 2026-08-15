//AI Generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Bookmark
{
    public class BookmarkDto : IMapFrom<BookmarkEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Descriptions { get; set; }
        public string UserId { get; set; } = string.Empty;

        // Chỉ một trong ba khoá dưới đây có giá trị, tuỳ dấu trang gắn vào đâu.
        public string? MangaId { get; set; }
        public string? MangaName { get; set; }
        public string? MangaThumbnail { get; set; }

        public string? ChapterId { get; set; }
        public int? ChapterIndex { get; set; }
        public int? ChapterSubIndex { get; set; }

        public string? BlogId { get; set; }
        public string? BlogTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookmarkEntity, BookmarkDto>();
        }
    }
}
