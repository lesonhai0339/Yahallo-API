using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Follow.GetAllPagination
{
    public class GetAllFollowMangaPaginationQueryHandler : IRequestHandler<GetAllFollowMangaPaginationQuery, PagedResult<FollowMangaDto>>
    {
        private readonly IFollowRepository _followRepository;
        public GetAllFollowMangaPaginationQueryHandler(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
    
        public async Task<PagedResult<FollowMangaDto>> Handle(GetAllFollowMangaPaginationQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q => q
                    .Select(x => new FollowMangaDto
                    {
                        MangaId = x.MangaId,
                        UserId = x.UserId,
                        MangaName = x.Manga.Name,
                        UserName = x.User.DisplayName,
                        Avatar = x.Manga.MangaThumbnail,
                        Background = x.Manga.MangaBackground,
                        LastUpdate = x.Manga.LastChapterUpdate
                    }),
                cancellation: cancellationToken);

            return follows.MapToPagedResult(x => x);
        }
    }
}
