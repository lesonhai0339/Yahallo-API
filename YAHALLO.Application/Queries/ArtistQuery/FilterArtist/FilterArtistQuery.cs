using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.ArtistQuery.FilterArtist
{
    public class FilterArtistQuery: IRequest<PagedResult<ArtistDto>>
    {
        public FilterArtistQuery() { }
        public FilterArtistQuery(
            int pageNumber, 
            int pageSize, 
            string? id, 
            string? name, 
            CountriesEnum? countries, 
            LifeStatus? lifeStatus)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;
            Name = name;
            Countries = countries;
            LifeStatus = lifeStatus;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id { get;set; }
        public string? Name { get; set; }
        public CountriesEnum? Countries { get; set; }
        public LifeStatus? LifeStatus { get; set; }
    }
}
