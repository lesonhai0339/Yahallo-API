using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.Manga.DTOs
{
    public class TopMangaDto: IMapFrom<MangaEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string MangaThumbnail { get; set; } = string.Empty;
        public long View { get; set;  }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MangaEntity, TopMangaDto>();
        }
    }
}
