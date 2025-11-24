using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;
using AutoMapper;
using YAHALLO.Infrastructure.Elastic1.Mappings;


namespace YAHALLO.Infrastructure.Elastic.Indexes
{
    public class MangaIndex: IMapFrom<MangaEntity>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Countries { get; set; }
        public int Season { get; set; }

        public string? MangaSeasonId { get; set; }
        public string[]? MangaSeasonEntity { get; set; }
        public string? UserId { get; set; }
        public string? UserEntity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaIndex>()
                .ForMember(dest => dest.MangaSeasonEntity,
                           opt => opt.MapFrom(src => src.MangaSeasonEntity != null
                               ? new[] { src.MangaSeasonEntity.Id }
                               : null))
                .ForMember(dest => dest.UserEntity,
                           opt => opt.MapFrom(src => src.UserEntity != null
                               ? src.UserEntity.UserName
                               : null))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => (int)src.Level))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => (int)src.Countries));
        }
    }
}
