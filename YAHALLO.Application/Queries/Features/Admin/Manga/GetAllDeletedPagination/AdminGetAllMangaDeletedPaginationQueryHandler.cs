using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Tag;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.GetAllDeletedPagination
{
    public sealed class AdminGetAllMangaDeletedPaginationQueryHandler : IRequestHandler<AdminGetAllMangaDeletedPaginationQuery, PagedResult<AdminMangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        public AdminGetAllMangaDeletedPaginationQueryHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }
        public async Task<PagedResult<AdminMangaDto>> Handle(AdminGetAllMangaDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository
                  .FindAllSelectAsync(
                  pageNo: request.PageNo,
                  pageSize: request.PageSize,
                  selector: x => x
                      .Where(m => !string.IsNullOrEmpty(m.IdUserDelete) && m.DeleteDate.HasValue)
                      .Select(t => new AdminMangaDto
                      {
                          Id = t.Id,
                          DisplayName = (t.Name + " " + t.SeasonName).Trim(),
                          Description = t.Description,
                          Level = t.Level,
                          Status = t.Status,
                          Type = t.Type,
                          Countries = t.Countries,
                          Season = t.Season,
                          MangaThumbnail = t.MangaThumbnail,
                          MangaBackground = t.MangaBackground,
                          UserId = t.UserId,
                          ViewCount = t.ViewCount == null ? 0 : t.ViewCount.TotalCount,
                          Rating = t.RatingEntities.Select(x => (int?)x.Rating).Average(),
                          LastestChapter = t.LastChapter == null ? null : new AdminChapterDto
                          {
                              Id = t.LastChapter.Id,
                              Index = t.LastChapter.Index,
                              CreateDate = t.LastChapter.CreateDate,
                              Title = t.LastChapter.Title,
                              MangaId = t.Id,
                              MangaName = t.Name
                          },
                          Tags = t.TagEntities.Select(t => new AdminTagDto
                          {
                              Id = t.TagId,
                              Name = t.Tag.Name,
                              Description = t.Tag.Description
                          }).ToList()
                      }),
                    cancellation: cancellationToken,
                    ignoreQueryFilters: true);
            return mangas.MapToPagedResult(x => x);
        }
    }
}
