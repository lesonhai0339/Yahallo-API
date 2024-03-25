using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.RoleCommand.Restore
{
    public class RestoreRoleCommandhandler : IRequestHandler<RestoreRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreRoleCommandhandler(IRoleRepository roleRepository, ICurrentUserService currentUser)
        {
            _roleRepository = roleRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(RestoreRoleCommand request, CancellationToken cancellationToken)
        {
            var checkRoleExist = await _roleRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkRoleExist == null)
            {
                throw new NotFoundException($"Không tìm thấy role với Id {request.Id}");
            }
            checkRoleExist.IdUserDelete = null;
            checkRoleExist.DeleteDate = null;
            checkRoleExist.UpdateDate = DateTime.Now;
            checkRoleExist.IdUserUpdate = _currentUser.UserId;
            _roleRepository.Update(checkRoleExist);
            var result= await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);   
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
