using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeteledPagination
{
    public sealed class GetAllCommentDeletedPaginationQueryHandler : IRequestHandler<GetAllCommentDeletedPaginationQuery, PagedResult<AdminCommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public GetAllCommentDeletedPaginationQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<PagedResult<AdminCommentDto>> Handle(GetAllCommentDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.FindAllSelectAsync(
            pageNo: request.PageNumber,
            pageSize: request.PageSize,
            selector: x => x
                .Where(c => !string.IsNullOrEmpty(c.IdUserDelete) && c.DeleteDate.HasValue)
                .Select(t => new AdminCommentDto
                {
                    Id = t.Id,
                    Like = t.LikeCount,
                    Dislike = t.DisLikeCount,
                    DateTime = t.CreateDate,
                    UserId = t.UserId,
                    MangaId = t.MangaId,
                    ChapterId = t.ChapterId,
                    ChapterName = t.ChapterEntity == null ? null : t.ChapterEntity.Title,
                    BlogId = t.BlogId,
                    ParentId = t.ParentId,
                    ReplyToCommentId = t.ReplyToCommentId,
                    Message = t.Message,
                    ReplyCount = t.Comments == null ? 0 : t.Comments.Count(),
                    IsDeleted = t.DeleteDate.HasValue && !string.IsNullOrEmpty(t.IdUserDelete),
                    DisplayName = t.UserEntity == null ? null : t.UserEntity.DisplayName,
                    Avatar = t.UserEntity == null ? null : t.UserEntity.AvatarThumbnail,
                    UserCommentTo = t.CommentToUser == null ? null : new UserDto
                    {
                        Id = t.CommentToUser.Id,
                        DisplayName = t.CommentToUser.DisplayName,
                        Avatar = t.CommentToUser.AvatarThumbnail
                    }
                }),
            cancellation: cancellationToken,
            ignoreQueryFilters: true);

            return comments.MapToPagedResult(x => x);
        }
    }
}
