using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.MangaQuery.FilterManga
{
    public class FilterMangaQuery: IRequest<PagedResult<MangaDto>>
    {
        public FilterMangaQuery() { }
        public FilterMangaQuery(
            int pageNumber, 
            int pageSizee, 
            string? id, 
            string? name, 
            MangaLevel? level, 
            MangaStatus? status, 
            MangaType? type, 
            CountriesEnum? countries, 
            int? season, 
            string? userId, 
            DateTime? dateUpdate)
        {
            PageNumber = pageNumber;
            PageSizee = pageSizee;
            Id = id;
            Name = name;
            Level = level;
            Status = status;
            Type = type;
            Countries = countries;
            Season = season;
            UserId = userId;
            DateUpdate = dateUpdate;
        }

        public int PageNumber { get; set; }
        public int PageSizee { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int? Season { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
