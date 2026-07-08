using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Comment.GetAllPagination
{
    public class GetAllCommentPaginationQueryHandler : IRequestHandler<GetAllCommentPaginationQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public GetAllCommentPaginationQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
    
        public async Task<PagedResult<CommentDto>> Handle(GetAllCommentPaginationQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q => q
                .Select(x => new CommentDto
                {
                    Id = x.Id,
                    Like = x.LikeCount,
                    Dislike = x.DisLikeCount,
                    DateTime = x.CreateDate,
                    UserId = x.UserId,
                    MangaId = x.MangaId,
                    ChapterId = x.ChapterId,
                    ChapterName = x.ChapterEntity == null ? null : x.ChapterEntity.Title,
                    BlogId = x.BlogId,
                    ParentId = x.ParentId,
                    ReplyToCommentId = x.ReplyToCommentId,
                    Message = x.Message,
                    ReplyCount = x.Comments == null ? 0 : x.Comments.Count(),
                    IsDeleted = x.DeleteDate.HasValue && !string.IsNullOrEmpty(x.IdUserDelete),
                    DisplayName = x.UserEntity == null ? null : x.UserEntity.DisplayName,
                    Avatar = x.UserEntity == null ? null : x.UserEntity.AvatarThumbnail,
                    UserCommentTo = x.CommentToUser == null ? null : new UserDto
                    {
                        Id = x.CommentToUser.Id,
                        DisplayName = x.CommentToUser.DisplayName,
                        Avatar = x.CommentToUser.AvatarThumbnail
                    }
                }),
                cancellation: cancellationToken); 

            return comments.MapToPagedResult(x => x);
        }
    }
}
