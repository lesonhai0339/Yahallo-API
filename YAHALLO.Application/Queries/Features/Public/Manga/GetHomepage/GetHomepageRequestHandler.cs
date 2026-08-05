using MediatR;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Keys;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Rating;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetHomepage
{
    public class GetHomepageRequestHandler : IRequestHandler<GetHomepageRequest, HomePageDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ICacheService _cache;
        private readonly CacheSettings _settings;
        private readonly IMangaDailyAnalyticsRepository _mangaDaily;
        public GetHomepageRequestHandler(
            IOptions<CacheSettings> options,
            IMangaRepository mangaRepository,
            ITagRepository tagRepository,
            IAuthorRepository authorRepository,
            IArtistRepository artistRepository,
            IMangaDailyAnalyticsRepository mangaDaily,
            ICacheService cache)
        {
            _settings = options.Value;
            _mangaRepository = mangaRepository;
            _tagRepository = tagRepository;
            _authorRepository = authorRepository;
            _artistRepository = artistRepository;
            _mangaDaily = mangaDaily;
            _cache = cache;
        }
        public async Task<HomePageDto> Handle(GetHomepageRequest request, CancellationToken cancellationToken)
        {
            var cached = await _cache.GetAsync<HomePageDto>(CacheKeys.Home, cancellationToken);
            if (cached != null)
                return cached;


            var now = DateTime.UtcNow;
            var date = now.Date;

            var startMonth = new DateTime(now.Year, now.Month, 1);
            var endMonth = startMonth.AddMonths(1);

            var startYear = new DateTime(now.Year, 1, 1);
            var endYear = startYear.AddYears(1);


            //New Manga take 12
            var newManga = await _mangaRepository.FindAllSelectAsync(
                pageNo: 1,
                pageSize: 12,
                selector: x => x
                .Where(x => x.DisplayMode == Domain.Enums.MangaEnums.DisplayMode.Visible)
                .OrderByDescending(m => m.CreateDate).ThenByDescending(m => m.Id)
                .Select(m => new MangaSumaryDto
                {
                    Id = m.Id,
                    DisplayName = m.Name,
                    MangaThumbnail = m.MangaThumbnail,
                    MangaBackground = m.MangaBackground,

                    LastChapterId = m.LastChapterId,
                    LastChapterIndex = m.LastChapterIndex,
                    LastChapterUpdate = m.LastChapterUpdate,

                    TotalViews = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                    AverageRating = m.RatingEntities.Select(r => (double?)r.Rating).Average() ?? 0,
                    Tags = m.TagEntities.Select(t => new TagDto
                    {
                        Id = t.TagId,
                        Name = t.Tag.Name,
                        Description = t.Tag.Description
                    }).ToList()
                }),
                cancellation: cancellationToken);

            //Last update take 12
            var lastChapterUpdate = await _mangaRepository.FindAllSelectAsync(
                pageNo: 1,
                pageSize: 12,
                selector: x => x
                .Where(x => x.DisplayMode == Domain.Enums.MangaEnums.DisplayMode.Visible)
                .OrderByDescending(m => m.LastChapterUpdate).ThenByDescending(m => m.Id)
                .Select(m => new MangaSumaryDto
                {
                    Id = m.Id,
                    DisplayName = m.Name,
                    MangaThumbnail = m.MangaThumbnail,
                    MangaBackground = m.MangaBackground,

                    LastChapterId = m.LastChapterId,
                    LastChapterIndex = m.LastChapterIndex,
                    LastChapterUpdate = m.LastChapterUpdate,

                    TotalViews = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                    AverageRating = m.RatingEntities.Select(r => (double?)r.Rating).Average() ?? 0,
                    Tags = m.TagEntities.Select(t => new TagDto
                    {
                        Id = t.TagId,
                        Name = t.Tag.Name,
                        Description = t.Tag.Description
                    }).ToList()
                }),
                cancellation: cancellationToken);

            //Popular
            var popular = await _mangaRepository.FindAllSelectAsync(
                pageNo: 1,
                pageSize: 6,
                selector: x => x
                .Where(x => x.DisplayMode == Domain.Enums.MangaEnums.DisplayMode.Visible)
               .OrderByDescending(m => m.ViewCount == null ? 0 : m.ViewCount.TotalCount).ThenByDescending(m => m.Id)
               .Select(m => new MangaSumaryDto
               {
                   Id = m.Id,
                   DisplayName = m.Name,
                   MangaThumbnail = m.MangaThumbnail,
                   MangaBackground = m.MangaBackground,
                   LastChapterId = m.LastChapterId,
                   LastChapterIndex = m.LastChapterIndex,
                   LastChapterUpdate = m.LastChapterUpdate ?? default,
                   TotalViews = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                   AverageRating = m.RatingEntities.Select(r => (double?)r.Rating).Average() ?? 0,
                   Tags = m.TagEntities.Select(t => new TagDto
                   {
                       Id = t.TagId,
                       Name = t.Tag.Name,
                       Description = t.Tag.Description
                   }).ToList()
               }), cancellationToken);

            //Tags
            var tags = await _tagRepository.FindAllSelectAsync(x => x
                .Select(t => new TagDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,    
                }),
                cancellationToken);

            var topByDate = await _mangaDaily.
                FindAllSelectAsync(
                pageNo: 1,
                pageSize: 5,
                selector: x => x
                    .Where(c => c.Date == date)
                    .OrderByDescending(o => o.ViewCount)
                    .Select(t => new TopMangaDto
                    {
                        Id = t.Manga != null ? t.Manga.Id : string.Empty,
                        DisplayName = t.Manga!.Name.Trim(),
                        MangaThumbnail = t.Manga.MangaThumbnail ?? "",
                        View = t.ViewCount
                    }),
                cancellationToken);

            var topByMonth = await _mangaDaily.
              FindAllSelectAsync(
              pageNo: 1,
              pageSize: 5,
              selector: x => x
                  .Where(c => c.Date >= startMonth && c.Date < endMonth)
                  .OrderByDescending(o => o.ViewCount)
                  .Select(t => new TopMangaDto
                  {
                      Id = t.Manga != null ? t.Manga.Id : string.Empty,
                      DisplayName = t.Manga!.Name.Trim(),
                      MangaThumbnail = t.Manga.MangaThumbnail ?? "",
                      View = t.ViewCount
                  }),
              cancellationToken);


            var topByYear = await _mangaDaily.
              FindAllSelectAsync(
              pageNo: 1,
              pageSize: 5,
              selector: x => x
                  .Where(c => c.Date >= startYear && c.Date < endYear)
                  .OrderByDescending(o => o.ViewCount)
                  .Select(t => new TopMangaDto
                  {
                      Id = t.Manga != null ? t.Manga.Id : string.Empty,
                      DisplayName = t.Manga!.Name.Trim(),
                      MangaThumbnail = t.Manga.MangaThumbnail ?? "",
                      View = t.ViewCount
                  }),
              cancellationToken);

            var homepage = new HomePageDto
            {
                NewManga = newManga.MapToPagedResult(x => x).Data.ToList(), 
                LastUpdate = lastChapterUpdate.MapToPagedResult(x => x).Data.ToList(),
                Popular = popular.MapToPagedResult(x => x).Data.ToList(),
                Tags = tags,
                TopMangaByDate = topByDate.MapToPagedResult(x => x).Data.ToList(),
                TopMangaByMonth = topByMonth.MapToPagedResult(x => x).Data.ToList(),
                TopMangaByYear = topByYear.MapToPagedResult(x => x).Data.ToList()
            };

            await _cache.SetAsync(
                CacheKeys.Home, 
                homepage, 
                TimeSpan.FromMinutes(_settings.HomepageTtlMinutes), 
                cancellationToken);

            return homepage;
        }
    }
}
