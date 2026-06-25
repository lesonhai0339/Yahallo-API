using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Delete
{
    public class DeleteUserSettingsCommandHandler : IRequestHandler<DeleteUserSettingsCommand, string>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IStorageService<UserSettingsBackground> _storageService;
        public DeleteUserSettingsCommandHandler(ICurrentUserService currentUser, IUserSettingsRepository userSettingsRepository, IStorageService<UserSettingsBackground> storageService)
        {
            _currentUser = currentUser;
            _userSettingsRepository = userSettingsRepository;
            _storageService = storageService;
        }

        public async Task<string> Handle(DeleteUserSettingsCommand request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff)
                throw new UnauthorizedAccessException("You do not have permission for this action");

            var setting = await _userSettingsRepository.FindAsync(
                x => x.UserId == request.UserId, cancellationToken);
            if (setting == null) throw new NotFoundException("Cannot found setting for user");

            setting.IdUserDelete = _currentUser.UserId; 
            setting.DeleteDate = DateTime.UtcNow;   

            _userSettingsRepository.Update(setting);
            var result = await _userSettingsRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0 ? "OK" : "Failed";
        }
    }
}
