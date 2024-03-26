using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserRoleCommand.Restore
{
    public class RestoreUserRoleCommandHandler : IRequestHandler<RestoreUserRoleCommand, string>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreUserRoleCommandHandler(IUserRoleRepository userRoleRepository,ICurrentUserService currentUser)
        {
            _userRoleRepository = userRoleRepository;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(RestoreUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkUserRoleExist = await _userRoleRepository
                .FindAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId
                && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkUserRoleExist == null)
            {
                throw new NotFoundException("Không tìm thấy UserRole này");
            }
            checkUserRoleExist.IdUserDelete = null;
            checkUserRoleExist.DeleteDate = null;
            checkUserRoleExist.IdUserUpdate = _currentUser.UserId;
            checkUserRoleExist.UpdateDate = DateTime.Now;
            _userRoleRepository.Update(checkUserRoleExist);
            var result = await _userRoleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return "Phục hồi thành công";
            }
            else
            {
                return "Phục hồi thất bại";
            }
        }
    }
}
