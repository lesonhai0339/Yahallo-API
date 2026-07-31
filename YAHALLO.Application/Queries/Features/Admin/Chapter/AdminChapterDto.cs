using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter
{
    public class AdminChapterDto : IMapFrom<ChapterEntity>
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public int? Index { get; set; }

        public string MangaId { get; set; } = null!;
        public string? MangaName { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterEntity, AdminChapterDto>();
        }
    }
}
