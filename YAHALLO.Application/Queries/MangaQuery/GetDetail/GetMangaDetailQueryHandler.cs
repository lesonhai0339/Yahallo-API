//AI generated
using AutoMapper;
using MediatR;
using System;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.AuthorQuery;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.CommentQuery;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Application.Repositories;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Application.Queries.MangaQuery.GetDetail
{
    public class GetMangaDetailQueryHandler : IRequestHandler<GetMangaDetailQuery, MangaDetailDto>
    {
        private readonly IMangaQueryRepository _mangaQueryRepository;
        private readonly ICacheService _cache;

        public GetMangaDetailQueryHandler(
            IMangaQueryRepository mangaQueryRepository,
            ICacheService cache)
        {
            _mangaQueryRepository = mangaQueryRepository;
            _cache = cache;
        }
        public async Task<MangaDetailDto> Handle(GetMangaDetailQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"manga:detail:{request.Id}";
            return await _cache.GetOrSetAsync(
                cacheKey,
                async () =>
                {
                    var manga = await _mangaQueryRepository.GetMangaDetail(request.Id, cancellationToken);
                    if(manga == null)
                        throw new NotFoundException("Manga not found"); 
                    return manga;
                },
                TimeSpan.FromMinutes(10),
                cancellationToken);
        }
    }
}
