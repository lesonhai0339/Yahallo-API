using MediatR;
using YAHALLO.Application.Queries.Features.Admin.User;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeleted
{
    public sealed class AdminGetAllCommentDeletedQueryHandler : IRequestHandler<AdminGetAllCommentDeletedQuery, List<AdminCommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public AdminGetAllCommentDeletedQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
    
        public async Task<List<AdminCommentDto>> Handle(AdminGetAllCommentDeletedQuery request, CancellationToken cancellationToken)
        {
            var comments= await _commentRepository.FindAllSelectAsync(x=> x 
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
                    UserCommentTo = t.CommentToUser == null ? null : new AdminUserDto
                    {
                        Id = t.CommentToUser.Id,
                        DisplayName = t.CommentToUser.DisplayName,
                        Avatar = t.CommentToUser.AvatarThumbnail
                    }
                }),
                cancellationToken, 
                ignoreQueryFilters: true);
            return comments;
        }
    }
}
