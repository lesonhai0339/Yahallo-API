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

namespace YAHALLO.Application.Queries.Features.Admin.Artist
{
    public class AdminArtistDto : IMapFrom<ArtistEntity>
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Depscription { get; set; }
        public DateTime Birth { get; set; }
        public string? LifeStatus { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArtistEntity, AdminArtistDto>();
        }
    }
}
