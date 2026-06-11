using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.FilterMangaByTag
{
    internal class FilterMangaByTagQueryHandler : IRequestHandler<FilterMangaByTagQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaTagRepository _mangaTagRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public FilterMangaByTagQueryHandler(IMangaTagRepository mangaTagRepository, IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaTagRepository = mangaTagRepository;
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<MangaDto>> Handle(FilterMangaByTagQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request.TagIds);
            var tags = request.TagIds.Split(',').Select(x => x.Trim()).ToList();        
            var mangaTag = await _mangaTagRepository.FindAllAsync(x => tags.Contains(x.TagId), cancellationToken);

            var matched = mangaTag
             .GroupBy(x => x.MangaId)
             .Where(g => g.Select(y => y.TagId).Distinct().Count() == tags.Count)
             .Select(x => x.Key)
             .ToList();
            var manga = await _mangaRepository.FindAllAsync(request.PageNumber, request.PageSize, x => x.Where(y => matched.Contains(y.Id)), cancellationToken);
            return manga.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
