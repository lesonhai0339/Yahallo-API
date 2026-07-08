using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Manga.DTOs
{
    public class MangaSumaryDto : IMapFrom<MangaEntity>
    {
        public required string Id { get; set; }
        public required string DisplayName { get; set; }  
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get; set; }    
        public long? TotalViews { get; set; }    
        public double? AverageRating { get; set; }

        public List<TagDto>? Tags { get; set; }


        //last chapter
        public string? LastChapterId { get; set; }
        public int? LastChapterIndex { get; set; }   
        public DateTime? LastChapterUpdate { get; set; }  
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, MangaSumaryDto>();
        }
    }
}
