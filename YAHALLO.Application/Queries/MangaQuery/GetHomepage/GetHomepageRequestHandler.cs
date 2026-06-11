using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Keys;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.MangaQuery.GetHomepage
{
    public class GetHomepageRequestHandler : IRequestHandler<GetHomepageRequest, HomePageDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ICacheService _cache;
        private readonly CacheSettings _settings;
        public GetHomepageRequestHandler(
            IOptions<CacheSettings> options,
            IMangaRepository mangaRepository,
            ITagRepository tagRepository,
            IAuthorRepository authorRepository,
            IArtistRepository artistRepository,
            ICacheService cache)
        {
            _settings = options.Value;
            _mangaRepository = mangaRepository;
            _tagRepository = tagRepository;
            _authorRepository = authorRepository;
            _artistRepository = artistRepository;
            _cache = cache;
        }
        public async Task<HomePageDto> Handle(GetHomepageRequest request, CancellationToken cancellationToken)
        {
            var cached = await _cache.GetAsync<HomePageDto>(CacheKeys.Home, cancellationToken);
            if (cached != null)
                return cached;

            //Last update take 12
            var lastUpdate = await _mangaRepository.FindAllSelectAsync(
                pageNo: 1,
                pageSize: 12,
                selector: x => x
                .OrderByDescending(m => m.LastChapterUpdate).ThenByDescending(m => m.Id)
                .Select(m => new MangaSumaryDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    MangaThumbnail = m.MangaThumbnail,
                    MangaBackground = m.MangaBackground,
                    LastChapterId = m.LastChapterId,
                    LastChapterIndex = m.LastChapterIndex,
                    LastChapterUpdate = m.LastChapterUpdate ?? default,
                    TotalViews = m.ViewCount == null ? 0 : m.ViewCount.ViewCount,
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
               .OrderByDescending(m => m.ViewCount == null ? 0 : m.ViewCount.ViewCount).ThenByDescending(m => m.Id)
               .Select(m => new MangaSumaryDto
               {
                   Id = m.Id,
                   Name = m.Name,
                   MangaThumbnail = m.MangaThumbnail,
                   MangaBackground = m.MangaBackground,
                   LastChapterId = m.LastChapterId,
                   LastChapterIndex = m.LastChapterIndex,
                   LastChapterUpdate = m.LastChapterUpdate ?? default,
                   TotalViews = m.ViewCount == null ? 0 : m.ViewCount.ViewCount,
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

            //Author
            var authors = await _authorRepository.FindAllSelectAsync(x => x
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Depscription = a.Depscription,
                    Countries = a.Countries,
                }),
                cancellationToken);


            //Artist
            var artists = await _artistRepository.FindAllSelectAsync(x => x
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Depscription = a.Depscription,
                    Countries = a.Countries
                }),
                cancellationToken);

            //Top manga by date, load 5(still not implement)
            var topMangaByDate = await _mangaRepository.FindAllSelectAsync(
                pageNo: 1,
                pageSize: 5,
                selector: x => x
                    .OrderByDescending(m => m.ViewCount == null ? 0 : m.ViewCount.ViewCount).ThenByDescending(m => m.Id)
                    .Select(m => new TopMangaDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        MangaThumbnail = m.MangaThumbnail ?? "",
                        View = m.ViewCount == null ? 0 : m.ViewCount.ViewCount
                    }),
                cancellation: cancellationToken
                );

            //Top manga by month,load 5(still not implement)
            var topMangaByMonth = topMangaByDate;

            //topmanga by year,load 5(still not implement)
            var topMangaByYear = topMangaByDate;

            var homepage = new HomePageDto
            {
                LastUpdate = lastUpdate.MapToPagedResult(x => x).Data.ToList(),
                Popular = popular.MapToPagedResult(x => x).Data.ToList(),
                Tags = tags,
                Authors = authors,
                Artists = artists,
                TopMangaByDate = topMangaByDate.MapToPagedResult(x => x).Data.ToList(),
                TopMangaByMonth = topMangaByMonth.MapToPagedResult(x => x).Data.ToList(),
                TopMangaByYear = topMangaByYear.MapToPagedResult(x => x).Data.ToList()
            };
            if (homepage == null)
                throw new Exception("Cannot load home page");

            await _cache.SetAsync(
                CacheKeys.Home, 
                homepage, 
                TimeSpan.FromMinutes(_settings.HomepageTtlMinutes), 
                cancellationToken);

            return homepage;
        }
    }
}
