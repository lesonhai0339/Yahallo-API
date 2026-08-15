//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ReactionEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Reaction.Filter
{
    public class FilterReactionQueryHandler : IRequestHandler<FilterReactionQuery, PagedResult<ReactionDto>>
    {
        private readonly IReactionRepository _reactionRepository;
        public FilterReactionQueryHandler(IReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }

        public async Task<PagedResult<ReactionDto>> Handle(FilterReactionQuery request, CancellationToken cancellationToken)
        {
            var reactions = await _reactionRepository.FindAllSelectAsync(
                request.PageNo,
                request.PageSize,
                selector: q =>
                    ApplySorting(ApplyFilter(q, request), request)
                        .Select(x => new ReactionDto
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            UserName = x.User!.DisplayName,
                            UserAvatar = x.User!.AvatarThumbnail,
                            Reaction = x.Reaction,
                            BlogId = x.BlogId,
                            CommentId = x.CommentId,
                            MangaId = x.MangaId,
                            ChapterId = x.ChapterId,
                            CreateDate = x.CreateDate,
                        }),
                cancellationToken);

            return reactions.MapToPagedResult(x => x);
        }

        private IQueryable<ReactionEntity> ApplySorting(IQueryable<ReactionEntity> filter, FilterReactionQuery request)
        {
            return request.SortBy switch
            {
                ReactionSortBy.Reaction => OrderHelper.ApplyOrder(filter, x => x.Reaction, request.ReverseSort),
                _ => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
            };
        }

        private IQueryable<ReactionEntity> ApplyFilter(IQueryable<ReactionEntity> query, FilterReactionQuery request)
        {
            if (!string.IsNullOrEmpty(request.BlogId)) query = query.Where(x => x.BlogId == request.BlogId);

            if (!string.IsNullOrEmpty(request.CommentId)) query = query.Where(x => x.CommentId == request.CommentId);

            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            if (!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ChapterId == request.ChapterId);

            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId == request.UserId);

            if (!string.IsNullOrEmpty(request.UserName))
                query = query.Where(x => x.User != null && x.User.DisplayName != null && x.User.DisplayName!.Contains(request.UserName));

            if (request.Reaction.HasValue) query = query.Where(x => x.Reaction == request.Reaction.Value);

            return query;
        }
    }
}
