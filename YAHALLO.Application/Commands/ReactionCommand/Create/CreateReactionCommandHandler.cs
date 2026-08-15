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
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    public class CreateReactionCommandHandler : IRequestHandler<CreateReactionCommand, bool>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateReactionCommandHandler(IReactionRepository reactionRepository, ICurrentUserService currentUser)
        {
            _reactionRepository = reactionRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để thả cảm xúc");

            // Bảng Reaction không có unique index trên (UserId, đối tượng) nên phải
            // tự tìm bản ghi cũ, nếu không mỗi lần bấm lại đẻ thêm một dòng.
            var existed = await _reactionRepository.FindAsync(
                BuildPredicate(request.TargetId, request.ReactionTo, userId), cancellationToken);

            if (existed is not null)
            {
                if (existed.Reaction == request.Reaction)
                {
                    // Bấm lại đúng loại đang có = gỡ cảm xúc.
                    existed.DeleteDate = DateTime.UtcNow;
                    existed.IdUserDelete = userId;
                    _reactionRepository.Update(existed);
                }
                else
                {
                    existed.Reaction = request.Reaction!.Value;
                    existed.DeleteDate = null;
                    existed.IdUserDelete = null;
                    existed.UpdateDate = DateTime.UtcNow;
                    existed.IdUserUpdate = userId;
                    _reactionRepository.Update(existed);
                }
            }
            else
            {
                var reaction = new ReactionEntity
                {
                    UserId = userId,
                    User = null!,
                    Reaction = request.Reaction!.Value,
                    CreateDate = DateTime.UtcNow,
                    IdUserCreate = userId,
                };
                AssignTarget(reaction, request.TargetId, request.ReactionTo);
                _reactionRepository.Add(reaction);
            }

            var result = await _reactionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        /// <summary>
        /// Điều kiện tìm cảm xúc CŨ của đúng người dùng này trên đúng đối tượng này.
        /// </summary>
        private static Expression<Func<ReactionEntity, bool>> BuildPredicate(
            string targetId, ReactionTargetEnum target, string userId)
        {
            return target switch
            {
                ReactionTargetEnum.Blog => x => x.UserId == userId && x.BlogId == targetId,
                ReactionTargetEnum.Comment => x => x.UserId == userId && x.CommentId == targetId,
                ReactionTargetEnum.Manga => x => x.UserId == userId && x.MangaId == targetId,
                _ => x => x.UserId == userId && x.ChapterId == targetId,
            };
        }

        private static void AssignTarget(ReactionEntity reaction, string targetId, ReactionTargetEnum target)
        {
            switch (target)
            {
                case ReactionTargetEnum.Blog: reaction.BlogId = targetId; break;
                case ReactionTargetEnum.Comment: reaction.CommentId = targetId; break;
                case ReactionTargetEnum.Manga: reaction.MangaId = targetId; break;
                default: reaction.ChapterId = targetId; break;
            }
        }
    }
}
