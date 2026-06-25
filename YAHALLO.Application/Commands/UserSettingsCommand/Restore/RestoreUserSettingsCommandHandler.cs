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

namespace YAHALLO.Application.Commands.UserSettingsCommand.Restore
{
    public class RestoreUserSettingsCommandHandler : IRequestHandler<RestoreUserSettingsCommand, RestoreUserSettingsResult>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserSettingsRepository _userSettingsRepository;
        public RestoreUserSettingsCommandHandler(ICurrentUserService currentUser, IUserSettingsRepository userSettingsRepository)
        {
            _currentUser = currentUser;
            _userSettingsRepository = userSettingsRepository;
        }
        public async Task<RestoreUserSettingsResult> Handle(RestoreUserSettingsCommand request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff)
                throw new UnauthorizedAccessException("You do not have permission for this action");

            var setting = await _userSettingsRepository.FindAsync(x => x.UserId == request.UserId && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken, ignoreQueryFilters: true);
            if (setting == null)
                throw new NotFoundException($"Setting for user {request.UserId} not found");

            setting.DeleteDate = null;
            setting.IdUserDelete = null;

            setting.UpdateDate = DateTime.UtcNow;
            setting.IdUserUpdate = _currentUser.UserId; 

            _userSettingsRepository.Update(setting);    
            var result = await _userSettingsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return new RestoreUserSettingsResult(Message: result > 0 ? "Thành công" : "Thất bại");
        }
    }
}
