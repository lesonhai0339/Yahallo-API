using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.ChapterQuery
{
    public class ChapterImageDto : IMapFrom<ImageEntity>
    {
        public required string Id { get; set; }
        public int? Index { get; set; }

        public string? CloudUrl { get; set; }


        public static ChapterImageDto CreateMap(string id, int index, string? cloundurl)    
        {
            return new ChapterImageDto
            {
                Id = id,
                Index = index,
                CloudUrl = cloundurl,  
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ImageEntity, ChapterImageDto>();
        }
    }
}
