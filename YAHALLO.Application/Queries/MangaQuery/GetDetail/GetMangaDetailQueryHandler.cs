//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.MangaQuery.GetDetail
{
    public class GetMangaDetailQueryHandler : IRequestHandler<GetMangaDetailQuery, MangaDetailDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMangaTagRepository _mangaTagRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;

        public GetMangaDetailQueryHandler(
            IMangaRepository mangaRepository,
            IMangaTagRepository mangaTagRepository,
            IMapper mapper,
            ICacheService cache)
        {
            _mangaRepository = mangaRepository;
            _mangaTagRepository = mangaTagRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<MangaDetailDto> Handle(GetMangaDetailQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"manga:detail:{request.Id}";

            return await _cache.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var manga = await _mangaRepository.FindAsync(
                        x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete),
                        cancellationToken);

                    if (manga is null) throw new NotFoundException($"Không tìm thấy manga: {request.Id}");

                    var dto = _mapper.Map<MangaDetailDto>(manga);

                    dto.Thumbnail = manga.Thumbnail?.BaseUrl ?? manga.Thumbnail?.CloudUrl ?? "";
                    dto.Level = manga.Level.GetDescription();
                    dto.Status = manga.Status.GetDescription();
                    dto.Type = manga.Type.GetDescription();
                    dto.Countries = manga.Countries.GetDescription();
                    dto.UserId = manga.UserId;

                    // Aggregated fields
                    dto.TotalFollows = manga.FollowEntities?.Count(f => string.IsNullOrEmpty(f.IdUserDelete)) ?? 0;
                    dto.TotalChapters = manga.ChaptersEntities?.Count(c => string.IsNullOrEmpty(c.IdUserDelete)) ?? 0;
                    dto.TotalViews = manga.ViewCount?.ViewCount ?? 0;

                    if (manga.RatingEntities != null && manga.RatingEntities.Any())
                        dto.AverageRating = manga.RatingEntities.Average(r => (double)r.Rating);

                    // Tags
                    var mangaTags = await _mangaTagRepository.FindAllAsync(x => x.MangaId == request.Id, cancellationToken);
                    dto.Tags = mangaTags
                        .Select(mt => new TagDto { Id = mt.TagId, Name = mt.Tag?.Name ?? "" })
                        .ToList();

                    return dto;
                },
                TimeSpan.FromMinutes(10),
                cancellationToken);
        }
    }
}
