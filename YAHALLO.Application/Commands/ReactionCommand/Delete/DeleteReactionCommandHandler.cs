//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReactionCommand.Delete
{
    public class DeleteReactionCommandHandler : IRequestHandler<DeleteReactionCommand, bool>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteReactionCommandHandler(IReactionRepository reactionRepository, ICurrentUserService currentUser)
        {
            _reactionRepository = reactionRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteReactionCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để thực hiện thao tác này");

            var reaction = await _reactionRepository.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (reaction is null)
                throw new NotFoundException($"Không tìm thấy cảm xúc với id {request.Id}");

            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff && reaction.UserId != userId)
                throw new UnAuthorizeException("Bạn không thể xoá cảm xúc của người khác");

            reaction.DeleteDate = DateTime.UtcNow;
            reaction.IdUserDelete = userId;
            _reactionRepository.Update(reaction);

            var result = await _reactionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
