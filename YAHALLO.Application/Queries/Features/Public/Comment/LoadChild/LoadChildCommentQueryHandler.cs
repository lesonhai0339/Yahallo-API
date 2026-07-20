using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Comment.LoadChild
{
    public class LoadChildCommentQueryHandler : IRequestHandler<LoadChildCommentQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public LoadChildCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<PagedResult<CommentDto>> Handle(LoadChildCommentQuery request, CancellationToken cancellationToken)
        {
            var cur = await _commentRepository.FindAsync(
                c => c.ParentId == request.ParentCommentId && c.Id == request.CommentId, cancellationToken);
            if (cur == null)
                throw new NotFoundException($"Not found comment with id {request.CommentId}");

            // Số reply ĐỨNG TRƯỚC cur theo thứ tự hiển thị (oldest-first)
            var before = await _commentRepository.CountAsync(c =>
                c.ParentId == request.ParentCommentId &&
                (c.CreateDate < cur.CreateDate ||
                  (c.CreateDate == cur.CreateDate && string.Compare(c.Id, cur.Id) < 0)),
                cancellationToken);

            var pageNo = before / request.PageSize + 1;   // giống load (chỉ khác chiều. RootComment xắp xếp theo mới nhất còn reply, mention xắp xếp theo thứ tự comment)

            var result = await _commentRepository.FindAllSelectAsync(
                pageNo: pageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(c => c.ParentId == request.ParentCommentId)
                    .OrderBy(c => c.CreateDate).ThenBy(c => c.Id) 
                    .Select(t => new CommentDto
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
                        IsDeleted = t.DeleteDate.HasValue,
                        IdUserDeleted = t.IdUserDelete,
                        DisplayName = t.UserEntity == null ? null : t.UserEntity.DisplayName,
                        Avatar = t.UserEntity == null ? null : t.UserEntity.AvatarThumbnail,
                        UserCommentTo = t.CommentToUser == null ? null : new UserDto
                        {
                            Id = t.CommentToUser.Id,
                            DisplayName = t.CommentToUser.DisplayName,
                            Avatar = t.CommentToUser.AvatarThumbnail
                        }
                    }),
                cancellationToken);

            return result.MapToPagedResult(x => x);
        }
    }
}
