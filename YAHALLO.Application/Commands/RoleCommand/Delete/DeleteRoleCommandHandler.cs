using MediatR;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.RoleCommand.Delete
{
    public class DeleteRoleCommandhandler : IRequestHandler<DeleteRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteRoleCommandhandler(IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, ICurrentUserService currentUser)
        {
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var checkRoleExist = await _roleRepository
                .FindAsync(x=> x.Id== request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkRoleExist == null)
            {
                throw new NotFoundException($"Không tìm thấy role nào với Id {request.Id}");
            }
            var checkUserInRoleExist= await _userRoleRepository
                .FindAllAsync(x=> x.RoleId == checkRoleExist.Id, cancellationToken);
            if(checkUserInRoleExist.Count() >0)
            {
                throw new ForeignKeyConstraintException($"Không thể xóa role do tồn tại {checkUserInRoleExist.Count()} thành viên có role này");
            }
            checkRoleExist.DeleteDate = DateTime.Now;
            checkRoleExist.IdUserDelete = _currentUser.UserId;
            _roleRepository.Update(checkRoleExist);
            var result= await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
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
