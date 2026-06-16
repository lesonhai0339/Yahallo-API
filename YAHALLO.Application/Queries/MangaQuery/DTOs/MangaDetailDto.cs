//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.CommentQuery;
using YAHALLO.Application.Queries.MangaQuery.GetDetail;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.MangaQuery.DTOs
{
    public class MangaDetailDto : IMapFrom<MangaEntity>
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
        public string? MangaBackground { get; set; }
        public string? UserId { get; set; }

        public List<TagDto> Tags { get; set; } = new();
        public List<ArtistDto> Artists { get; set; } = new();
        public List<AuthorDto> Authors { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaDetailDto>();
        }
    }
}
