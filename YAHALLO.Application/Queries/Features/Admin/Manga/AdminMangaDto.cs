using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
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
        public MangaType? Type { get; set; }
        public CountriesEnum? Countries { get; set; }
        public int Season { get; set; }
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get; set; }
        public long? ViewCount { get; set; }
        public double? Rating { get; set; }
        public string? UserId { get; set; }
        public AdminChapterDto? LastestChapter { get; set; }
        public List<AdminTagDto>? Tags { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, AdminMangaDto>();
        }
    }
}
