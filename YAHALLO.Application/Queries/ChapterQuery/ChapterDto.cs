//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ChapterQuery
{
    public class ChapterDto : IMapFrom<ChapterEntity>
    {
        public required string Id { get; set; }
        public string? Title { get; set; }
        public int? Index { get; set; }

        public string MangaId { get; set; } = null!;
        public string? MangaName { get; set; }
        public DateTime? CreateDate { get; set; }

        public static ChapterDto CreateMap(string id, string? title, int index, string mangaid, string manganame, DateTime createDate)
        {
            return new ChapterDto
            {
                Id = id,
                Title = title,
                Index = index,
                MangaId = mangaid,
                MangaName = manganame,
                CreateDate = createDate 
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterEntity, ChapterDto>();
        }
    }
}