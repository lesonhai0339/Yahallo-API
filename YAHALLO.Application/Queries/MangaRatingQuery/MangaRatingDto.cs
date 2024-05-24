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
        public required string MangaId { get; set; }
        public string? MangaName { get; set; }
        public required string Userid {get;set;}
        public string? UserName { get;set; } 

        public static MangaRatingDto CreateMap(string mangaid,string manganame, string userid, string username)
        {
            return new MangaRatingDto
            {
                MangaId = mangaid,
                Userid = userid,
                UserName = username,
                MangaName = manganame,
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaRatingEntity, MangaRatingDto>(); 
        }
    }
}
