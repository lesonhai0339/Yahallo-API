//AI generated
using MediatR;

namespace YAHALLO.Application.Queries.MangaQuery.GetTrending
{
    public class GetTrendingMangaQuery : IRequest<List<MangaDto>>
    {
        /// <summary>Look back this many days when computing trending score.</summary>
        public int DaysWindow { get; set; } = 7;
        public int Take { get; set; } = 20;
    }
}
