using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Comment;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Elastic;

namespace YAHALLO.Application.Queries.CommentQuery.FilterComment
{
    public class FilterCommentQueryHandler : IRequestHandler<FilterCommentQuery, PagedResult<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mapgaRepository;
        public FilterCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository, IMangaRepository mapgaRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _mapgaRepository = mapgaRepository;
        }
    
        public async Task<PagedResult<CommentDto>> Handle(FilterCommentQuery request, CancellationToken cancellationToken)
        {
            var query = _commentRepository.CreateQueryable();

            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var comments = await _commentRepository.FindAllSelectAsync(
                pageNo: request.PageNumber,
                pageSize: request.PageSize,
                selector: _=> query.Select(x => new CommentDto
                {
                    Id = x.Id,
                    Like = x.LikeCount,
                    Dislike = x.DisLikeCount,
                    DateTime = x.CreateDate,
                    UserId = x.UserId,
                    MangaId = x.MangaId,
                    ChapterId = x.ChapterId,
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
                cancellation: cancellationToken,
                ignoreQueryFilters: true); //Get all

            if (!comments.Any())
                throw new InvalidDataException("No Data");
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
            if(!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ChapterId == request.ChapterId);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.ParentId))
                query = query.Where(x => x.ParentId == request.ParentId);
            else
                query = query.Where(x => x.ParentId == null);

            return query;
        }
    }
}
