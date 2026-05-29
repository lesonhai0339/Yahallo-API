//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Queries.ArtistQuery;
using YAHALLO.Application.Queries.CommentQuery;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Domain.Entities;
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
        private readonly IChapterRepository _chapterRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMangaAuthorRepository _mangaAuthorRepository;
        private readonly IMangaArtistRepository _mangaArtistRepository;
        private readonly IMangaRatingRepository _mangaRatingRepository;

        public GetMangaDetailQueryHandler(
            IMangaRepository mangaRepository,
            IMangaTagRepository mangaTagRepository,
            IMapper mapper,
            IChapterRepository chapterRepository,
            ICommentRepository commentRepository,
            IMangaAuthorRepository mangaAuthorRepository,
            IMangaArtistRepository mangaArtistRepository,
            IMangaRatingRepository mangaRatingRepository,
            ICacheService cache)
        {
            _mangaRepository = mangaRepository;
            _mangaTagRepository = mangaTagRepository;
            _chapterRepository = chapterRepository;
            _commentRepository = commentRepository;
            _mangaAuthorRepository = mangaAuthorRepository;
            _mangaArtistRepository = mangaArtistRepository;
            _mangaRatingRepository = mangaRatingRepository;
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

                    //Chapters
                    var chapters = await _chapterRepository.FindAllAsync(x => x.MangaId == dto.Id, cancellationToken);
                    dto.Chapters = chapters.Select(c => _mapper.Map<ChapterDto>(c)).ToList();

                    //Comments
                    var comments = await _commentRepository.FindAllAsync(x => x.MangaId == dto.Id, cancellationToken);
                    dto.Comments = comments.Select(c => _mapper.Map<CommentDto>(c)).ToList();

                    //Author
                    var authors = await _mangaAuthorRepository.FindAllAsync(x => x.MangaId == dto.Id, cancellationToken);
                    dto.Authors = authors.Select(c => _mapper.Map<AuthorDto>(c)).ToList();
                    //Artist
                    var artists = await _mangaArtistRepository.FindAllAsync(x => x.MangaId == dto.Id, cancellationToken);
                    dto.Artists = artists.Select(c => _mapper.Map<ArtistDto>(c)).ToList();


                    //Rating
                    var rating = await _mangaRatingRepository.FindAllAsync(x => x.MangaId == dto.Id, cancellationToken);    
                    return dto;
                },
                TimeSpan.FromMinutes(10),
                cancellationToken);
        }
    }
}
