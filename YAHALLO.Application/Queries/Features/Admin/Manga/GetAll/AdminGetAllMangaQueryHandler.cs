using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Tag;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.GetAll
{
    public class AdminGetAllMangaQueryHandler : IRequestHandler<AdminGetAllMangaQuery, PagedResult<AdminMangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        public AdminGetAllMangaQueryHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository; 
        }
        public async Task<PagedResult<AdminMangaDto>> Handle(AdminGetAllMangaQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository.FindAllSelectAsync(
               pageSize: request.PageSize,
               pageNo: request.PageNo,
               selector: x => x
                   .OrderByDescending(x => x.LastChapterUpdate)
                   .Select(m => new AdminMangaDto
                   {
                       Id = m.Id,
                       DisplayName = m.Name,
                       Description = m.Description,
                       Level = m.Level,
                       Status = m.Status,
                       Mode = m.DisplayMode,
                       Type = m.Type,
                       Countries = m.Countries,
                       Season = m.Season,
                       MangaThumbnail = m.MangaThumbnail,
                       MangaBackground = m.MangaBackground,
                       TotalView = m.ViewCount == null ? null : m.ViewCount.TotalCount,
                       Rating = m.RatingEntities.Select(x => (double?)x.Rating).Average(),
                       Owner = new Owner
                       {
                           Id = m.UserEntity.Id,
                           Name = m.UserEntity.DisplayName
                       },
                       Tags = m.TagEntities.Select(x => new AdminTagDto
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
