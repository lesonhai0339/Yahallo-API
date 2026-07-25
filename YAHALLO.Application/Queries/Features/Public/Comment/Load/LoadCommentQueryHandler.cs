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
                     .Select(x => !x.DeleteDate.HasValue ? new CommentDto
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
                         IsDeleted = x.DeleteDate.HasValue,
                         DisplayName = x.UserEntity == null ? null : x.UserEntity.DisplayName,
                         Avatar = x.UserEntity == null ? null : x.UserEntity.AvatarThumbnail,
                         UserCommentTo = x.CommentToUser == null ? null : new UserDto
                         {
                             Id = x.CommentToUser.Id,
                             DisplayName = x.CommentToUser.DisplayName,
                             Avatar = x.CommentToUser.AvatarThumbnail
                         }
                     }
                    : new CommentDto
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        MangaId = x.MangaId,
                        ChapterId = x.ChapterId,
                        BlogId = x.BlogId,
                        ParentId = x.ParentId,
                        ReplyToCommentId = x.ReplyToCommentId,
                        IsDeleted = x.DeleteDate.HasValue,
                        ReplyCount = x.Comments == null ? 0 : x.Comments.Count()
                    }),
               cancellationToken,
               ignoreQueryFilters: true);

            return result.MapToPagedResult(x => x);
        }
        
     }
}
