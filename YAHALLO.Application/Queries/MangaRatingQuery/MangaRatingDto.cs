using AutoMapper;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.MangaRatingQuery
{
    public class MangaRatingDto : IMapFrom<MangaRatingEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string MangaId { get; set; } = string.Empty;
        public string? MangaName { get; set; }
        public required string Userid {get;set;}
        public string? UserName { get;set; } 
        public int ? Rating { get; set; }   
        public static MangaRatingDto CreateMap(string id, string mangaid,string manganame, string userid, string username, int rating)
        {
            return new MangaRatingDto
            {
                Id = id,
                MangaId = mangaid,
                Userid = userid,
                UserName = username,
                MangaName = manganame,
                Rating = rating 
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaRatingEntity, MangaRatingDto>(); 
        }
    }
}
