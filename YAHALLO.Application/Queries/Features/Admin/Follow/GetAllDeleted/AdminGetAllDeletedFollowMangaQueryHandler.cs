using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeleted
{
    public sealed class AdminGetAllDeletedFollowMangaQueryHandler : IRequestHandler<AdminGetAllDeletedFollowMangaQuery, List<AdminFollowDto>>
    {
        private readonly IFollowRepository _followrepository;
        public AdminGetAllDeletedFollowMangaQueryHandler(IFollowRepository followrepository)
        {
            _followrepository = followrepository;
        }
        public async Task<List<AdminFollowDto>> Handle(AdminGetAllDeletedFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followrepository.FindAllSelectAsync(x => x
                .Where(f => !string.IsNullOrEmpty(f.IdUserDelete) && f.DeleteDate.HasValue)
                .Select(t => new AdminFollowDto
                {
                    MangaId = t.MangaId,
                    UserId = t.UserId,
                    UserAvatar = t.User.AvatarThumbnail,

                    MangaThumbnail = t.Manga.MangaThumbnail,
                    MangaBackground = t.Manga.MangaBackground,
                    UserName = t.User.DisplayName,
                    MangaName = t.Manga.Name,
                    CreateDate = t.CreateDate,
                    UpdateDate = t.UpdateDate,
                    DeleteDate = t.DeleteDate,
                }), 
                cancellationToken, 
                ignoreQueryFilters: true);

            return follows;
        }
    }
}
