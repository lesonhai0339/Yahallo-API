using MediatR;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Tag;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.GetAllDeleted
{
    public sealed class AdminGetAllMangaDeletedQueryHandler : IRequestHandler<AdminGetAllMangaDeletedQuery, List<AdminMangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        public AdminGetAllMangaDeletedQueryHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public async Task<List<AdminMangaDto>> Handle(AdminGetAllMangaDeletedQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository
                .FindAllSelectAsync(x => x
                    .Where(m => !string.IsNullOrEmpty(m.IdUserDelete) && m.DeleteDate.HasValue)
                    .Select(t => new AdminMangaDto
                    {
                        Id = t.Id,
                        DisplayName = t.Name,
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
                    cancellationToken, 
                    ignoreQueryFilters: true);
            return mangas;
        }
    }
}
