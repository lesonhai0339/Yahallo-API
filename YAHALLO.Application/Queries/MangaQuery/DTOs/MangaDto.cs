using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.MangaQuery.DTOs
{
    public class MangaDto : IMapFrom<MangaEntity>
    {
        public required string Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? Description { get; set; }
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int Season { get; set; }
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground{ get; set; }
        public long? ViewCount { get; set;  }
        public double? Rating { get; set; }
        public string? UserID { get; set; }
        public ChapterDto? LastestChapter { get; set; } 
        public static MangaDto Createmap(
            string id,
            string name,
            string description,
            MangaLevel level,
            MangaStatus status,
            MangaType type,
            CountriesEnum country,
            int season,
            string thumbnail,
            string background,  
            string userid)
        {
            return new MangaDto
            {
                Id = id,
                DisplayName = name,
                Description = description,
                Level = level,
                Status = status,
                Type = type,
                Countries = country,
                Season = season,
                MangaThumbnail = thumbnail,
                MangaBackground = background,   
                UserID = userid,
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaDto>();
        }
    }
}
