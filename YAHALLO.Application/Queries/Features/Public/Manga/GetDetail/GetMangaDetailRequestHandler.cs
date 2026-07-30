//AI generated
using MediatR;
using Microsoft.Extensions.Options;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Common.Keys;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetDetail
{
    public class GetMangaDetailRequestHandler : IRequestHandler<GetMangaDetailRequest, MangaDetailDto>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICacheService _cache;
        private readonly CacheSettings _settings;
        public GetMangaDetailRequestHandler(
            IOptions<CacheSettings> options,
            IMangaRepository mangaRepository,
            ICacheService cache)
        {
            _settings = options.Value;
            _mangaRepository = mangaRepository;
            _cache = cache;
        }
        public async Task<MangaDetailDto> Handle(GetMangaDetailRequest request, CancellationToken cancellationToken)
        {
            var cache = await _cache.GetAsync<MangaDetailDto>(CacheKeys.MangaDetail(request.Id), cancellationToken);
            if (cache != null)
                return cache;

            var manga = await _mangaRepository.FindSelectAsync(e => e
                .Where(x => x.Id == request.Id && x.DisplayMode == Domain.Enums.MangaEnums.DisplayMode.Visible)
                .Select(t => new MangaDetailDto
                {
                    Id = t.Id,
                    DisplayName = t.Name.Trim(),
                    Description = t.Description,
                    Level = t.Level,
                    Status = t.Status,
                    Type = t.Type,
                    Countries = t.Countries,
                    Season = t.Season,
                    MangaThumbnail = t.MangaThumbnail,
                    MangaBackground = t.MangaBackground,
                    UserId = t.UserId,
                    Rating = t.RatingEntities.Select(x => (double?)x.Rating).Average(),
                    CommentCount = t.CommentEntities.Count(),
                    ViewCount = t.ViewCount == null ? 0 : t.ViewCount.TotalCount,
                    Tags = t.TagEntities
                    .Select(x => new TagDto
                    {
                        Id = x.TagId,
                        Name = x.Tag.Name,
                        Description = x.Tag.Description,    
                    }) .ToList(),
                    Authors = t.AuthorEntities
                    .Select(a => new AuthorDto
                    {
                        Id = a.AuthorId,
                        Name = a.Author.Name,
                        Birth = a.Author.Birth,
                        Countries = a.Author.Countries,
                        Depscription = a.Author.Depscription,
                        LifeStatus = a.Author.LifeStatus,   
                    }).ToList(),
                    Artists = t.ArtistEntities
                    .Select(a => new ArtistDto
                    {
                        Id = a.ArtistId,
                        Name = a.Artist.Name,
                        Birth = a.Artist.Birth,
                        Countries = a.Artist.Countries,
                        Depscription = a.Artist.Depscription,
                        LifeStatus = a.Artist.LifeStatus,
                    }).ToList()
                }), cancellationToken);
            if(manga == null)
                throw new NotFoundException($"Manga detail for id {request.Id} not found");

            await _cache.SetAsync(
                key: CacheKeys.MangaDetail(request.Id),
                value: manga,
                TimeSpan.FromMinutes(_settings.MangaDetailTtlMinutes),
                cancellationToken);

            return manga;
        }
    }
}
