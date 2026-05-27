using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Kafka;
using YAHALLO.Infrastructure.Redis;

namespace YAHALLO.Application.Queries.MangaQuery.GetCatalog
{
    public class GetMangaCatalogQueryHandler : IRequestHandler<GetMangaCatalogQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IRedisCacheService _cache;
        private readonly IKafkaProducer _kafkaProducer;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMangaCatalogQueryHandler> _logger;

        public GetMangaCatalogQueryHandler(
            IMangaRepository mangaRepository,
            IRedisCacheService cache,
            IKafkaProducer kafkaProducer,
            IMapper mapper,
            ILogger<GetMangaCatalogQueryHandler> logger)
        {
            _mangaRepository = mangaRepository;
            _cache = cache;
            _kafkaProducer = kafkaProducer;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedResult<MangaDto>> Handle(GetMangaCatalogQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = MangaCacheKeys.Catalog(ToCacheSegment(request.Type), request.PageNumber, request.PageSize);
            var cached = await _cache.GetAsync<PagedResult<MangaDto>>(cacheKey, cancellationToken);
            if (cached != null)
            {
                return cached;
            }

            var query = _mangaRepository.CreateQueryable()
                .Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);

            query = ApplyOrdering(query, request.Type);

            var mangas = await _mangaRepository.FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if (mangas.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ manga nào");
            }

            var result = mangas.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
            await _cache.SetAsync(cacheKey, result, TimeSpan.FromMinutes(10), cancellationToken);
            await _kafkaProducer.PublishAsync(
                null,
                cacheKey,
                new
                {
                    Event = "MangaCatalogLoaded",
                    request.Type,
                    request.PageNumber,
                    request.PageSize,
                    OccurredAtUtc = DateTime.UtcNow
                },
                cancellationToken);

            _logger.LogInformation("Loaded manga catalog {CatalogType} from database and cached key {CacheKey}.", request.Type, cacheKey);
            return result;
        }

        private static IQueryable<MangaEntity> ApplyOrdering(IQueryable<MangaEntity> query, GetMangaCatalogType type)
        {
            return type switch
            {
                GetMangaCatalogType.Newest => query
                    .OrderByDescending(x => x.CreateDate ?? DateTime.MinValue)
                    .ThenByDescending(x => x.Id),

                GetMangaCatalogType.Popular => query
                    .OrderByDescending(x => x.FollowEntities == null ? 0 : x.FollowEntities.Count)
                    .ThenByDescending(x => x.RatingEntities == null ? 0 : x.RatingEntities.Count)
                    .ThenByDescending(x => x.MangaView == null ? 0 : x.MangaView.View),

                GetMangaCatalogType.TopViewDay => query
                    .Where(x => (x.MangaView != null && x.MangaView.UpdateDate >= DateTime.Today)
                        || (x.MangaView != null && x.MangaView.CreateDate >= DateTime.Today))
                    .OrderByDescending(x => x.MangaView == null ? 0 : x.MangaView.View),

                GetMangaCatalogType.TopViewMonth => query
                    .Where(x => (x.MangaView != null && x.MangaView.UpdateDate >= FirstDayOfMonth(DateTime.Today))
                        || (x.MangaView != null && x.MangaView.CreateDate >= FirstDayOfMonth(DateTime.Today)))
                    .OrderByDescending(x => x.MangaView == null ? 0 : x.MangaView.View),

                GetMangaCatalogType.TopViewYear => query
                    .Where(x => (x.MangaView != null && x.MangaView.UpdateDate >= FirstDayOfYear(DateTime.Today))
                        || (x.MangaView != null && x.MangaView.CreateDate >= FirstDayOfYear(DateTime.Today)))
                    .OrderByDescending(x => x.MangaView == null ? 0 : x.MangaView.View),

                _ => query.OrderByDescending(x => x.CreateDate ?? DateTime.MinValue)
            };
        }

        private static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private static DateTime FirstDayOfYear(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        private static string ToCacheSegment(GetMangaCatalogType type)
        {
            return type switch
            {
                GetMangaCatalogType.Newest => "newest",
                GetMangaCatalogType.Popular => "popular",
                GetMangaCatalogType.TopViewDay => "top-view-day",
                GetMangaCatalogType.TopViewMonth => "top-view-month",
                GetMangaCatalogType.TopViewYear => "top-view-year",
                _ => "newest"
            };
        }
    }
}

