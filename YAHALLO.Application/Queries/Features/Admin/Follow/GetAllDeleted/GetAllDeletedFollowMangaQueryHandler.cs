using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeleted
{
    public sealed class GetAllDeletedFollowMangaQueryHandler : IRequestHandler<GetAllDeletedFollowMangaQuery, List<AdminFollowDto>>
    {
        private readonly IFollowRepository _followrepository;
        public GetAllDeletedFollowMangaQueryHandler(IFollowRepository followrepository)
        {
            _followrepository = followrepository;
        }
        public async Task<List<AdminFollowDto>> Handle(GetAllDeletedFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followrepository.FindAllSelectAsync(x => x
                .Where(f => !string.IsNullOrEmpty(f.IdUserDelete) && f.DeleteDate.HasValue)
                .Select(t => new AdminFollowDto
                {
                    MangaId = t.MangaId,
                    UserId = t.UserId,
                    MangaThumbnail = t.Manga.MangaThumbnail,
                    MangaBackground = t.Manga.MangaBackground,
                    UserName = t.User.DisplayName,
                    MangaName = t.Manga.Name,
                    LastUpdate = t.Manga.LastChapterUpdate  
                }), 
                cancellationToken, 
                ignoreQueryFilters: true);

            return follows;
        }
    }
}
