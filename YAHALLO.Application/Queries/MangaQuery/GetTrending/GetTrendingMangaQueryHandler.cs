//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.MangaQuery.GetTrending
{
    public class GetTrendingMangaQueryHandler : IRequestHandler<GetTrendingMangaQuery, List<MangaDto>>
    {
        private readonly IUserMangaViewRepository _viewRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;

        public GetTrendingMangaQueryHandler(
            IUserMangaViewRepository viewRepository,
            IMangaRepository mangaRepository,
            IMapper mapper,
            ICacheService cache)
        {
            _viewRepository = viewRepository;
            _mangaRepository = mangaRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<MangaDto>> Handle(GetTrendingMangaQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"manga:trending:{request.DaysWindow}d:{request.Take}";

            return await _cache.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var since = DateTime.Now.AddDays(-request.DaysWindow);

                    // Get top manga IDs ordered by unique user views in the window
                    var topMangaIds = _viewRepository.CreateQueryable()
                        .Where(v => v.ViewedAt >= since)
                        .GroupBy(v => v.MangaId)
                        .OrderByDescending(g => g.Count())
                        .Select(g => g.Key)
                        .Take(request.Take)
                        .ToList();

                    var mangas = await _mangaRepository.FindAllAsync(
                        x => topMangaIds.Contains(x.Id) && string.IsNullOrEmpty(x.IdUserDelete),
                        cancellationToken);

                    // Preserve trending order
                    var ordered = topMangaIds
                        .Select(id => mangas.FirstOrDefault(m => m.Id == id))
                        .Where(m => m is not null)
                        .Select(m => m!.MapFullToMangaDto(_mapper))
                        .ToList();

                    return ordered;
                },
                TimeSpan.FromMinutes(15),
                cancellationToken);
        }
    }
}
