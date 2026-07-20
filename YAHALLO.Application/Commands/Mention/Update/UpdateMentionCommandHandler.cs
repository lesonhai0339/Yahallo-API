using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.Mention.Update
{
    public class UpdateMentionCommandHandler : IRequestHandler<UpdateMentionCommand, bool>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IMentionRepository _mentionRepository;
        public UpdateMentionCommandHandler(ICurrentUserService currentUser, IMentionRepository mentionRepository)
        {
            _currentUser = currentUser;
            _mentionRepository = mentionRepository;
        }
        public async Task<bool> Handle(UpdateMentionCommand request, CancellationToken cancellationToken)
        {

            var mention = await _mentionRepository.FindAsync(x => x.Id == request.Id && x.UserId == _currentUser.UserId, cancellationToken);
            if (mention == null)
                throw new NotFoundException($"Cannot find mention with id {request.Id}");

            mention.Seen = true;
            mention.UpdateDate = DateTime.UtcNow;
            mention.IdUserUpdate = _currentUser.UserId;

            _mentionRepository.Update(mention);
            var result = await _mentionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
