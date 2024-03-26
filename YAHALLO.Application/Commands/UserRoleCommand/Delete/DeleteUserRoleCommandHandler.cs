using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserRoleCommand.Delete
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, string>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteUserRoleCommandHandler(IUserRoleRepository userRole, ICurrentUserService currentUser)
        {
            _userRoleRepository = userRole;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkUserRoleExist = await _userRoleRepository
                .FindAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkUserRoleExist == null)
            {
                throw new NotFoundException($"Không tìm thấy UserRole với UserId: {request.UserId} và RoleId: {request.RoleId}");
            }
            checkUserRoleExist.IdUserDelete = _currentUser.UserId;
            checkUserRoleExist.DeleteDate = DateTime.Now;
            _userRoleRepository.Update(checkUserRoleExist);
            var result = await _userRoleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}
