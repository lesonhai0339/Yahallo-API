using MediatR;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Suggest
{
    public sealed class GetSuggestQueryHandler : IRequestHandler<GetSuggestQuery, PagedResult<SuggestResult>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IArtistRepository _artistRepository;
        public  GetSuggestQueryHandler(
            IMangaRepository mangaRepository,
            ITagRepository tagRepository,
            IAuthorRepository authorRepository,
            IArtistRepository artistRepository
            )
        {
            _mangaRepository = mangaRepository;
            _tagRepository = tagRepository;
            _authorRepository = authorRepository;
            _artistRepository = artistRepository;   
        }
        public async Task<PagedResult<SuggestResult>> Handle(GetSuggestQuery request, CancellationToken cancellationToken)
        {
            var keyword = request.Keyword.Trim();
            var resuslts = request.Type switch
            {
                SuggestType.Tag => await _tagRepository.FindAllSelectAsync(
                    pageNo: 1,
                    pageSize: request.MaxResults,
                    selector: x => x
                        .Where(t => t.Name.StartsWith(keyword))
                        .SelectMany(m => m.MangaTagEntities
                            .Select(x => x.Manga))
                        .OrderBy(t => t.Name)
                        .Select(x => new SuggestResult
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Type = SuggestType.Tag,
                            ThumbnailUrl = x.MangaThumbnail,
                        }),
                    cancellationToken),


                SuggestType.Author => await _authorRepository.FindAllSelectAsync(
                    pageNo: 1,
                    pageSize: request.MaxResults,
                     selector: x => x
                        .Where(t => t.Name.StartsWith(keyword))
                        .SelectMany(m => m.MangaAuthorEntities
                            .Select(x => x.Manga))
                        .OrderBy(t => t.Name)
                        .Select(x => new SuggestResult
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Type = SuggestType.Tag,
                            ThumbnailUrl = x.MangaThumbnail,
                        }),
                    cancellationToken),


                SuggestType.Artist => await _artistRepository.FindAllSelectAsync(
                    pageNo: 1,
                    pageSize: request.MaxResults,
                      selector: x => x
                        .Where(t => t.Name.StartsWith(keyword))
                        .SelectMany(m => m.MangaArtistEntities
                            .Select(x => x.Manga))
                        .OrderBy(t => t.Name)
                        .Select(x => new SuggestResult
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Type = SuggestType.Tag,
                            ThumbnailUrl = x.MangaThumbnail,
                        }),
                    cancellationToken),


                SuggestType.Manga => await _mangaRepository.FindAllSelectAsync(
                    pageNo: 1,
                    pageSize: request.MaxResults,
                    selector: x => x
                        .Where(t => t.Name.StartsWith(keyword))
                        .OrderBy(t => t.Name)
                        .Select(x => new SuggestResult
                        {
                            Id = x.Id,
                            ThumbnailUrl = x.MangaThumbnail,
                            Name = x.Name,
                            Type = SuggestType.Manga,
                        }),
                    cancellationToken),


                _ => throw new UnSupportedException(nameof(request.Type)),
            };
            return resuslts.MapToPagedResult(x => x);
        }
    }
}
