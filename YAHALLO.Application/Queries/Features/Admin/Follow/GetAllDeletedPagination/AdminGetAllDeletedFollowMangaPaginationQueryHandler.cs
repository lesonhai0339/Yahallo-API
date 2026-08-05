using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeletedPagination
{
    public sealed class AdminGetAllDeletedFollowMangaPaginationQueryHandler : IRequestHandler<AdminGetAllDeletedFollowMangaPaginationQuery, PagedResult<AdminFollowDto>>
    {
        private readonly IFollowRepository _followRepository;
        public AdminGetAllDeletedFollowMangaPaginationQueryHandler(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
        public async Task<PagedResult<AdminFollowDto>> Handle(AdminGetAllDeletedFollowMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followRepository.FindAllSelectAsync(
            pageNo: request.PageNo,
            pageSize: request.PageSize,
            selector:    x => x
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
            cancellation:   cancellationToken,
            ignoreQueryFilters: true);

            return follows.MapToPagedResult(x => x);
        }
    }
}
