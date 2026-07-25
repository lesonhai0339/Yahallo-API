using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Comment;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Comment.FilterComment
{
    public class FilterCommentQueryHandler : IRequestHandler<FilterCommentQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        public FilterCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
    
        public async Task<PagedResult<CommentDto>> Handle(FilterCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
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
                cancellation: cancellationToken,
                ignoreQueryFilters: true);

            return comments.MapToPagedResult(x => x);
        }

        private IQueryable<CommentEntity> ApplyFilter(IQueryable<CommentEntity> query, FilterCommentQuery request)
        {
            return request.SortBy switch
            {
                CommentSortBy.Time => OrderHelper.ApplyOrder(query, x => x.CreateDate, request.ReverseSort),
                CommentSortBy.Like => OrderHelper.ApplyOrder(query, x => x.LikeCount, request.ReverseSort),
                CommentSortBy.Dislike => OrderHelper.ApplyOrder(query, x => x.DisLikeCount, request.ReverseSort),
                _ => query.OrderBy(x => x.Id)
            };
        }
        private IQueryable<CommentEntity> ApplySorting(IQueryable<CommentEntity> query, FilterCommentQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id.Equals(request.Id));
            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId!.Equals(request.UserId));
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ChapterId == request.ChapterId);
            if (!string.IsNullOrEmpty(request.ParentId))
                query = query.Where(x => x.ParentId == request.ParentId);
            else
                query = query.Where(x => x.ParentId == null);

            return query;
        }
    }
}
