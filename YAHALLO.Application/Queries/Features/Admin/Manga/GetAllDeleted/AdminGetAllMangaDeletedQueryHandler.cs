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
                    .Select(m => new AdminMangaDto
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
                        TotalView = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                        Rating = m.RatingEntities.Select(x => (int?)x.Rating).Average(),
                        Owner = new Owner
                        {
                            Id = m.UserEntity.Id,
                            Name = m.UserEntity.DisplayName
                        },
                        Tags = m.TagEntities.Select(t => new AdminTagDto
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
