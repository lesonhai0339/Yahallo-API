using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public class MangaSumaryDto : IMapFrom<MangaEntity>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }  
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get; set; }    
        public int? TotalViews { get; set; }    
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
