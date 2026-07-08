//AI generated
using MediatR;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetTrending
{
    public class GetTrendingMangaQuery : IRequest<List<MangaDto>>
    {
        /// <summary>Look back this many days when computing trending score.</summary>
        public int DaysWindow { get; set; } = 7;
        public int Take { get; set; } = 20;
    }
}
