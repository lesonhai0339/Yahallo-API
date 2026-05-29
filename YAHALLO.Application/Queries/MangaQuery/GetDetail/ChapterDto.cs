//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.MangaQuery.GetDetail
{
    public class ChapterDto: IMapFrom<ChapterEntity>
    {
        public required string Id { get; set; }  
        public string? Title { get; set; }
        public int Index { get; set; }

        public string MangaId { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterEntity, ChapterDto>();
        }
    }
}