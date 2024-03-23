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

namespace YAHALLO.Application.Queries.AuthorQuery
{
    public class AuthorDto : IMapFrom<AuthorEntity>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public CountriesEnum? Countries { get; set; }
        public string? Depscription { get; set; }
        public DateTime? Birth { get; set; }
        public LifeStatus? LifeStatus { get; set; }
        public AuthorDto Create(string id, string? name, CountriesEnum? countries, string? depsctiption, DateTime? birth, LifeStatus? lifeStatus)
        {
            return new AuthorDto
            {
                Id = id,
                Name = name,
                Countries = countries,
                Depscription = depsctiption,
                Birth = birth,
                LifeStatus = lifeStatus
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthorEntity, AuthorDto>();
        }
    }
}
