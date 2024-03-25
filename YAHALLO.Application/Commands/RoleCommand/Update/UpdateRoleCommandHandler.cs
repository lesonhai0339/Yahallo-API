using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.RoleCommand.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateRoleCommandHandler(IRoleRepository roleRepository, ICurrentUserService currentUser)
        {
            _roleRepository = roleRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var checkRoleExist = await _roleRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkRoleExist == null)
            {
                throw new NotFoundException($"Không tìm thấy role với Id {request.Id}");
            }
            var checkRoleCodeExists= await _roleRepository
                .FindAllAsync(x=> x.RoleCode == request.RoleCode, cancellationToken);   
            if(checkRoleCodeExists.Count() >1)
            {
                throw new DuplicateException($"Đã tồn tại role với role code {request.RoleCode}");
            }
            checkRoleExist.RoleCode = request.RoleCode ?? checkRoleExist.RoleCode;
            checkRoleExist.RoleName = request.RoleName ?? checkRoleExist.RoleName;
            checkRoleExist.RoleDescription = request.RoleDescription ?? checkRoleExist.RoleDescription;
            checkRoleExist.UpdateDate = DateTime.Now;
            checkRoleExist.IdUserUpdate = _currentUser.UserId;
            _roleRepository.Update(checkRoleExist);
            var result = await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result >0)
            {
                return "Cập nhật thành công";
            }
            else
            {
                return "Cập nhật thất bại";
            }
        }
    }
}
