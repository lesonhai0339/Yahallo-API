using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public class MangaDto : IMapFrom<MangaEntity>
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
        public string? UserID { get; set; }

        public static MangaDto Createmap(
            string id,
            string name,
            string description,
            string level,
            string status,
            string type,
            string country,
            int season,
            string thumbnail,
            string userid)
        {
            return new MangaDto
            {
                Id = id,
                Name = name,
                Description = description,
                Level = level,
                Status = status,
                Type = type,
                Countries = country,
                Season = season,
                Thumbnail = thumbnail,
                UserID = userid
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaDto>();
        }
    }
}
