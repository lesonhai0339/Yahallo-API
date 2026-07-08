using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.Features.Public.Artist.FilterArtist
{
    public class FilterArtistQuery: IRequest<PagedResult<ArtistDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? Id { get;set; }
        public string? Name { get; set; }
    }
}
