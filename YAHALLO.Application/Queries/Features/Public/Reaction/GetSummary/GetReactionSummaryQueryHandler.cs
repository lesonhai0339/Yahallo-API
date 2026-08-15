//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ReactionEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Reaction.GetSummary
{
    public class GetReactionSummaryQueryHandler : IRequestHandler<GetReactionSummaryQuery, ReactionSummaryDto>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly ICurrentUserService _currentUser;
        public GetReactionSummaryQueryHandler(IReactionRepository reactionRepository, ICurrentUserService currentUser)
        {
            _reactionRepository = reactionRepository;
            _currentUser = currentUser;
        }

        public async Task<ReactionSummaryDto> Handle(GetReactionSummaryQuery request, CancellationToken cancellationToken)
        {
            // Gom cả hai loại trong MỘT truy vấn rồi đếm trong bộ nhớ: hai lần
            // CountAsync sẽ là hai vòng round-trip cho cùng một tập dòng.
            var rows = await _reactionRepository.FindAllSelectAsync(
                q => ApplyTarget(q, request.TargetId, request.ReactionTo)
                        .Select(x => new { x.Reaction, x.UserId }),
                cancellationToken);

            var userId = _currentUser.UserId;

            return new ReactionSummaryDto
            {
                TargetId = request.TargetId,
                ReactionTo = request.ReactionTo,
                LikeCount = rows.Count(x => x.Reaction == ReactionEnum.Like),
                DislikeCount = rows.Count(x => x.Reaction == ReactionEnum.Dislike),
                MyReaction = string.IsNullOrEmpty(userId)
                    ? null
                    : rows.Where(x => x.UserId == userId)
                          .Select(x => (ReactionEnum?)x.Reaction)
                          .FirstOrDefault(),
            };
        }

        private static IQueryable<ReactionEntity> ApplyTarget(
            IQueryable<ReactionEntity> query, string targetId, ReactionTargetEnum target)
        {
            return target switch
            {
                ReactionTargetEnum.Blog => query.Where(x => x.BlogId == targetId),
                ReactionTargetEnum.Comment => query.Where(x => x.CommentId == targetId),
                ReactionTargetEnum.Manga => query.Where(x => x.MangaId == targetId),
                _ => query.Where(x => x.ChapterId == targetId),
            };
        }
    }
}
