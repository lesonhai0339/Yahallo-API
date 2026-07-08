using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.Features.Public.Manga.FilterManga
{
    public class FilterMangaQuery: IRequest<PagedResult<MangaDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? TagIds { get; set; }  
        public string? AuthorId { get; set; }    
        public string? ArtistId { get; set; }   
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int Season { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public MangaSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } 
    }
}
