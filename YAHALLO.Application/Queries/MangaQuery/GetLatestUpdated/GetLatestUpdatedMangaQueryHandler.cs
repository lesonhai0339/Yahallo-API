//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.TagQuery;
using YAHALLO.Application.Repositories;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetLatestUpdated
{
    public class GetLatestUpdatedMangaQueryHandler : IRequestHandler<GetLatestUpdatedMangaQuery, PagedResult<MangaSumaryDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMangaQueryRepository _mangaQueryRepository;
        private readonly IMapper _mapper;

        public GetLatestUpdatedMangaQueryHandler(IMangaRepository mangaRepository, IMangaQueryRepository mangaQueryRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mangaQueryRepository = mangaQueryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaSumaryDto>> Handle(GetLatestUpdatedMangaQuery request, CancellationToken cancellationToken)
        {
            var page = await _mangaRepository.FindAllSelectAsync(
                pageNo: request.PageNumber,
                pageSize: request.PageSize,
                selector: x => x
                .Where(m => string.IsNullOrEmpty(m.IdUserDelete) && !m.DeleteDate.HasValue)
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
                
            if (page == null)
                throw new InvalidDataException("Data empty");

            return page.MapToPagedResult(x => x);
        }
    }
}
