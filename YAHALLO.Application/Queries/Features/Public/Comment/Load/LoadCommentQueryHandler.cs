using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Comment.Load
{
    public class LoadCommentQueryHandler : IRequestHandler<LoadCommentQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public LoadCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<PagedResult<CommentDto>> Handle(LoadCommentQuery request, CancellationToken cancellationToken)
        {
            var root = await _commentRepository.FindSelectAsync( x => x
                    .Where(c => c.Id == request.RootCommentId),
                cancellationToken);
            if (root == null)
                throw new NotFoundException($"Comment not found");

            var count = await _commentRepository.CountAsync(x => 
                x.MangaId == root.MangaId  &&
                x.ChapterId ==  root.ChapterId && 
                x.BlogId == root.BlogId &&
                x.ParentId == null &&  
                x.CreateDate > root.CreateDate, 
                cancellationToken);

            var pageNo = (count + request.PageSize - 1) / request.PageSize;
            var result = await _commentRepository.FindAllSelectAsync(
                pageNo: pageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(x => x.MangaId == root.MangaId && x.ChapterId == root.ChapterId && x.BlogId == x.BlogId && x.ParentId == null)
                    .OrderByDescending(x => x.CreateDate)
                    .Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Like = c.LikeCount,
                        Dislike = c.DisLikeCount,
                        DateTime = c.CreateDate,
                        UserId = c.UserId,
                        MangaId = c.MangaId,
                        ChapterId = c.ChapterId,
                        ChapterName = c.ChapterEntity == null ? null : c.ChapterEntity.Title,
                        BlogId = c.BlogId,
                        ParentId = c.ParentId,
                        ReplyToCommentId = c.ReplyToCommentId,
                        Message = c.Message,
                        ReplyCount = c.Comments == null ? 0 : c.Comments.Count(),
                        IsDeleted = c.DeleteDate.HasValue,
                        IdUserDeleted = c.IdUserDelete,
                        DisplayName = c.UserEntity == null ? null : c.UserEntity.DisplayName,
                        Avatar = c.UserEntity == null ? null : c.UserEntity.AvatarThumbnail,
                        UserCommentTo = c.CommentToUser == null ? null : new UserDto
                        {
                            Id = c.CommentToUser.Id,
                            DisplayName = c.CommentToUser.DisplayName,
                            Avatar = c.CommentToUser.AvatarThumbnail
                        }
                    }),
               cancellationToken);

            return result.MapToPagedResult(x => x);
        }
        
     }
}
