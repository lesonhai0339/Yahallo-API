using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.GetAllDeletedPagination
{
    public sealed class GetAllDeletedFollowMangaPaginationQueryHandler : IRequestHandler<GetAllDeletedFollowMangaPaginationQuery, PagedResult<AdminFollowDto>>
    {
        private readonly IFollowRepository _followRepository;
        public GetAllDeletedFollowMangaPaginationQueryHandler(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
        public async Task<PagedResult<AdminFollowDto>> Handle(GetAllDeletedFollowMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followRepository.FindAllSelectAsync(
            pageNo: request.PageNumber,
            pageSize: request.PageSize,
            selector:    x => x
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
            cancellation:   cancellationToken,
            ignoreQueryFilters: true);

            return follows.MapToPagedResult(x => x);
        }
    }
}
