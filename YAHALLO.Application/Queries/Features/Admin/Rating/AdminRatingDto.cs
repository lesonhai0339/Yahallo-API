using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Manga;
using YAHALLO.Application.Queries.Features.Admin.User;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Rating
{
    public class AdminRatingDto : IMapFrom<RatingEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public double? Rating { get; set; }
        public AdminMangaDto? Manga { get; set; }
        public AdminChapterDto? Chapter { get; set; }
        public AdminUserDto? User { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RatingEntity, AdminRatingDto>();
        }
    }

}
