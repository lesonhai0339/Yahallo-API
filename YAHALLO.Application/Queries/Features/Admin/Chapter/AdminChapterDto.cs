using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter
{
    public class AdminChapterDto : IMapFrom<ChapterEntity>
    {
        public required string Id { get; set; }
        public string? Title { get; set; }
        public int? Index { get; set; }

        public string MangaId { get; set; } = null!;
        public string? MangaName { get; set; }
        public DateTime? CreateDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChapterEntity, AdminChapterDto>();
        }
    }
}
