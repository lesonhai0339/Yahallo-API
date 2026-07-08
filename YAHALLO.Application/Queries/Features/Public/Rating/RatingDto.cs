using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Rating
{
    public class RatingDto : IMapFrom<RatingEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string? UserName { get;set; } 
        public double ? Rating { get; set; }   
        public MangaDto? Manga { get; set; }    
        public ChapterDto? Chapter { get; set; }
        public UserDto? User { get; set; }
        public static RatingDto CreateMap(string id, string userid, string username, int rating, MangaDto? manga, ChapterDto? chapter, UserDto? user)
        {
            return new RatingDto
            {
                Id = id,
                UserId = userid,
                UserName = username,
                Rating = rating ,
                Manga = manga,
                Chapter = chapter,
                User = user 
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RatingEntity, RatingDto>(); 
        }
    }
}
