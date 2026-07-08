using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Artist.Filter
{
    public sealed class AdminFilterArtistQuery : PaginationQuery<AdminArtistDto>
    {
        public string? Id { get; set;  }
        public string? Name { get; set; }   
        public CountriesEnum? Country { get; set; }
        public LifeStatus? LifeStatus { get; set; } 
        public bool IsDeleted { get; init; } = false;
    }
}
