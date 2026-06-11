using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.TagQuery;

namespace YAHALLO.Application.Queries.MangaQuery
{
    public class HomePageDto
    {
        public List<MangaSumaryDto> LastUpdate { get; set; } = new List<MangaSumaryDto>();
        public List<MangaSumaryDto> Popular { get; set; } = new List<MangaSumaryDto>();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public List<AuthorDto> Authors { get; set; } = new List<AuthorDto>();
        public List<ArtistDto> Artists { get; set; } = new List<ArtistDto>();
        public List<TopMangaDto> TopMangaByDate { get; set; } = new List<TopMangaDto>();
        public List<TopMangaDto> TopMangaByMonth { get; set; } = new List<TopMangaDto>();
        public List<TopMangaDto> TopMangaByYear { get; set; } = new List<TopMangaDto>();
    }
}
