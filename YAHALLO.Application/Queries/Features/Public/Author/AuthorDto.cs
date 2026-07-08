//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.Features.Public.Author
{
    public class AuthorDto: IMapFrom<AuthorEntity>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public CountriesEnum Countries { get; set; }
        public string? Depscription { get; set; }
        public DateTime Birth { get; set; }
        public LifeStatus LifeStatus { get; set; }
        public static AuthorDto Create(string id, string? name, CountriesEnum countries, string depscription, DateTime birth, LifeStatus lifestatus)
        {
            return new AuthorDto
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
            profile.CreateMap<AuthorEntity,AuthorDto>();
        }
    }
}