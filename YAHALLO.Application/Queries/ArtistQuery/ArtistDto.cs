using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.ArtistQuery
{
    public class ArtistDto : IMapFrom<ArtistEntity>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public CountriesEnum Countries { get; set; }
        public string? Depscription { get; set; }
        public DateTime Birth { get; set; }
        public LifeStatus LifeStatus { get; set; }
        public static ArtistDto Create(string id, string? name, CountriesEnum countries,string depscription, DateTime birth, LifeStatus lifestatus)
        {
            return new ArtistDto
            {
                Id = id,
                Name = name,
                Countries = countries,
                Depscription = depscription,
                Birth = birth,
                LifeStatus = lifestatus
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArtistEntity, ArtistDto>();
        }
    }
}
