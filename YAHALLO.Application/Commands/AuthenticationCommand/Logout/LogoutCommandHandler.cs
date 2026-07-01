using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthenticationCommand.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly ICurrentUserService _currentUser;
        public LogoutCommandHandler(IUserTokenRepository userTokenRepository, ICurrentUserService currentUser)
        {
            _userTokenRepository = userTokenRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Un anthorize");

            var userToken = await _userTokenRepository.FindAsync(x => x.Id == request.SessionId && x.UserId == _currentUser.UserId, cancellationToken);
            if (userToken == null)
                throw new NotFoundException($"Not found token for session id {request.SessionId}");

            _userTokenRepository.Remove(userToken);
            var result = await _userTokenRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
