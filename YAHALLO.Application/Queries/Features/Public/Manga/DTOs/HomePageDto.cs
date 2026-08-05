using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Application.Queries.Features.Public.Tag;

namespace YAHALLO.Application.Queries.Features.Public.Manga.DTOs
{
    public class HomePageDto
    {
        public List<MangaSumaryDto> NewManga { get; set; } = new List<MangaSumaryDto>();
        public List<MangaSumaryDto> LastUpdate { get; set; } = new List<MangaSumaryDto>();
        public List<MangaSumaryDto> Popular { get; set; } = new List<MangaSumaryDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public List<TopMangaDto> TopMangaByDate { get; set; } = new List<TopMangaDto>();
        public List<TopMangaDto> TopMangaByMonth { get; set; } = new List<TopMangaDto>();
        public List<TopMangaDto> TopMangaByYear { get; set; } = new List<TopMangaDto>();
    }
}
