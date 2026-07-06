using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.Hubs.UpdateLastActive
{
    public class UpdateLastActiveCommandHandler : IRequestHandler<UpdateLastActiveCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdateLastActiveCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateLastActiveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
                return false;

            user.LastActiveTime = DateTime.UtcNow;

            _userRepository.Update(user);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
