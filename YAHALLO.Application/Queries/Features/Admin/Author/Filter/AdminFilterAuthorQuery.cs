using YAHALLO.Application.Queries.Features.Admin.Artist;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Author.Filter
{
    public sealed class AdminFilterAuthorQuery: PaginationQuery<AdminAuthorDto>
    {
        public string? Id { get; init; }
        public string? Name { get; init; }
        public CountriesEnum? Country { get; init; }
        public LifeStatus? LifeStatus { get; init; }
        public bool IsDeleted { get; init; } = false;
    }
}
