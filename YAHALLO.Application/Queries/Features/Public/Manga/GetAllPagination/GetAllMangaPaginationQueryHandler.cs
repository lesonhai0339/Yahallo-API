using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetAllPagination
{
    public class GetAllMangaPaginationQueryHandler : IRequestHandler<GetAllMangaPaginationQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public GetAllMangaPaginationQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MangaDto>> Handle(GetAllMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository.FindAllSelectAsync(
                pageSize: request.PageSize,
                pageNo: request.PageNo,
                selector: x => x
                    .Where(x => x.DisplayMode == Domain.Enums.MangaEnums.DisplayMode.Visible)
                    .OrderByDescending(x => x.LastChapterUpdate)
                    .Select(m => new MangaDto
                    {
                        Id = m.Id,
                        DisplayName = m.Name,
                        Description = m.Description,
                        Level = m.Level,
                        Status = m.Status,
                        Type = m.Type,
                        Countries = m.Countries,
                        Season = m.Season,
                        MangaThumbnail = m.MangaThumbnail,
                        MangaBackground = m.MangaBackground,
                        ViewCount = m.ViewCount == null ? null : m.ViewCount.TotalCount,
                        Rating = m.RatingEntities.Select(x => (double?)x.Rating).Average(),
                        UserId = m.UserId,
                        LastestChapter = new ChapterDto
                        {
                            Id = m.LastChapterId,
                            Index = m.LastChapterIndex,
                            CreateDate = m.LastChapterUpdate,
                            Title = m.LatestChapterTitle,
                        },
                        Tags = m.TagEntities.Select(x => new TagDto
                        {
                            Id = x.TagId,
                            Description = x.Tag.Description,
                            Name = x.Tag.Name
                        }).ToList()
                    })
                , cancellation: cancellationToken);

            return mangas.MapToPagedResult(x => x);
        }
    }
}
