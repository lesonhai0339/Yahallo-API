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
    public class ChapterImageDto : IMapFrom<ChapterImageEntity>
    {
        public required string Id { get; set; }
        public int? Index { get; set; }

        public string? Url { get; set; }
        public string? ResizeUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ResizeWidth { get; set; }
        public int ResizeHeight { get; set; }
        public string? ContentType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterImageEntity, ChapterImageDto>();
        }
    }
}
