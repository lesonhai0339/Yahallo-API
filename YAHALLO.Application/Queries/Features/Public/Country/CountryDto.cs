using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Country
{
    public class CountryDto : IMapFrom<CountryEntity>
    {
        public string Id { get; set; } = string.Empty;
        public int Code { get; set;  }
        public int PhoneCode { get; set; } 
        public int FaxCode { get; set; }    
        public string? Name { get; set;  }
        public string? FullName { get; set; }   
        public string? VietnameseName { get; set;  }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CountryEntity, CountryDto>();
        }
    }
}
