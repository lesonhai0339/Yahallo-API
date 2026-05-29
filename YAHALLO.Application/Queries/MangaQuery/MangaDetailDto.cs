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

namespace YAHALLO.Application.Queries.MangaQuery
{
    public class MangaDetailDto : IMapFrom<MangaEntity>
    {
        public required string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Level { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public string? Countries { get; set; }
        public int Season { get; set; }
        public string? Thumbnail { get; set; }
        public string? UserId { get; set; }

        // Aggregated
        public double AverageRating { get; set; }
        public int TotalFollows { get; set; }
        public int TotalViews { get; set; }
        public int TotalChapters { get; set; }
        public List<TagDto> Tags { get; set; } = new();
        public List<ArtistDto> Artists { get; internal set; } = new();
        public List<ChapterDto> Chapters { get; internal set; } = new();
        public List<CommentDto> Comments { get; internal set; } = new();
        internal List<AuthorDto> Authors { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaDetailDto>();
        }
    }
}
