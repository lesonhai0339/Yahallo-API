using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.AuthorQuery.FilterAuthor
{
    public class FilterAuthorQuery: IRequest<PagedResult<AuthorDto>>
    {
        public FilterAuthorQuery() { }
        public FilterAuthorQuery(
            int pageNumber, 
            int pageSize, 
            string? id, 
            string? name, 
            CountriesEnum? countries, 
            DateTime? birth, 
            LifeStatus? lifeStatus)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Id = id;
            Name = name;
            Countries = countries;
            Birth = birth;
            LifeStatus = lifeStatus;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Id { get; set; } = null!;
        public string? Name { get; set; }
        public CountriesEnum? Countries { get; set; }
        public DateTime? Birth { get; set; }
        public LifeStatus? LifeStatus { get; set; }
    }
}
