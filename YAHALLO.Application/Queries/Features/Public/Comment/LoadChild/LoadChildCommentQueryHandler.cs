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
