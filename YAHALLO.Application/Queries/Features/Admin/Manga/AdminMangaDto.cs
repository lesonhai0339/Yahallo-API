using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.Features.Admin.Artist;
using YAHALLO.Application.Queries.Features.Admin.Author;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Tag;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Queries.Features.Admin.Manga
{
    public class AdminMangaDto : IMapFrom<MangaEntity>
    {
        public required string Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? Description { get; set; }
        public MangaLevel? Level { get; set; }
        public MangaStatus? Status { get; set; }
        public DisplayMode? Mode { get; set; }  
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int Season { get; set; }
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get; set; }
        public  int? TotalChapter { get; set; }
        public long? TotalView { get; set; }
        public int? TotalComment { get; set; } 
        public double? Rating { get; set; }
        public DateTime? CreateDate { get; set; }   
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public List<AdminTagDto>? Tags { get; set; }
        public List<AdminAuthorDto>? Authors { get; set; }
        public List<AdminArtistDto>? Artists { get; set; }

        public Owner? Owner { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, AdminMangaDto>();
        }
    }
    public class Owner
    {
        public string? Id { get; set; }  
        public string? Name { get; set; }
    }
}
