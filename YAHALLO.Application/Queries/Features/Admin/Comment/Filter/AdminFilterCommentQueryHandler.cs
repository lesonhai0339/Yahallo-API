using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.User;
using YAHALLO.Application.Queries.Features.Public.Comment;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Comment;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.Filter
{
    public sealed class AdminFilterCommentQueryHandler : IRequestHandler<AdminFilterCommentQuery, PagedResult<AdminCommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;   
        public AdminFilterCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;   
        }

        public async Task<PagedResult<AdminCommentDto>> Handle(AdminFilterCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(x => new AdminCommentDto
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
                        ReplyCount = x.Comments.Count(),
                        IsDeleted = x.DeleteDate.HasValue,
                        IdUserDeleted = x.IdUserDelete,
                        DisplayName = x.UserEntity == null ? null : x.UserEntity.DisplayName,
                        Avatar = x.UserEntity == null ? null : x.UserEntity.AvatarThumbnail,
                        CreateDate = x.CreateDate,
                        DeleteDate = x.DeleteDate,
                        UserCommentTo = x.CommentToUser == null ? null : new AdminUserDto
                        {
                            Id = x.CommentToUser.Id,
                            DisplayName = x.CommentToUser.DisplayName,
                            Avatar = x.CommentToUser.AvatarThumbnail
                        }
                    }),
                cancellation: cancellationToken,
                ignoreQueryFilters: request.IsDeleted);

            return comments.MapToPagedResult(x => x);
        }
        private IQueryable<CommentEntity> ApplyFilter(IQueryable<CommentEntity> query, AdminFilterCommentQuery request)
        {
            return request.SortBy switch
            {
                CommentSortBy.Time => OrderHelper.ApplyOrder(query, x => x.CreateDate, request.ReverseSort),
                CommentSortBy.Like => OrderHelper.ApplyOrder(query, x => x.LikeCount, request.ReverseSort),
                CommentSortBy.Dislike => OrderHelper.ApplyOrder(query, x => x.DisLikeCount, request.ReverseSort),
                _ => query.OrderBy(x => x.Id)
            };
        }
        private IQueryable<CommentEntity> ApplySorting(IQueryable<CommentEntity> query, AdminFilterCommentQuery request)
        {
            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id.Equals(request.Id));
            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId!.Equals(request.UserId));
            if (!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ChapterId == request.ChapterId);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.ParentId))
                query = query.Where(x => x.ParentId == request.ParentId);
            else
                query = query.Where(x => x.ParentId == null);


            if(request.From != null && request.To != null)
            {
                var from = request.From.Value.AddMinutes(-request.TimeZoneOffset);
                var to = request.To.Value.AddDays(1).AddMinutes(-request.TimeZoneOffset);
                query = query.Where(x => x.CreateDate >= from && x.CreateDate <= to);
            }

            if (request.IsDeleted)
                query = query.Where(x => x.DeleteDate.HasValue);

            return query;
        }
    }
}
