using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Restore
{
    public class RestoreUserCommandHandler : IRequestHandler<RestoreUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _curreentUser;
        public RestoreUserCommandHandler(IUserRepository userRepository, ICurrentUserService curreentUser)
        {
            _userRepository = userRepository;
            _curreentUser = curreentUser;
        }
        public async Task<string> Handle(RestoreUserCommand request, CancellationToken cancellationToken)
        {
            var checkUserExists = await _userRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkUserExists == null)
            {
                throw new NotFoundException($"Không tìm thấy thành viên với Id {request.Id}");
            }
            checkUserExists.DeleteDate = null;
            checkUserExists.IdUserDelete = null;
            checkUserExists.UpdateDate = DateTime.Now;
            checkUserExists.IdUserUpdate = _curreentUser.UserId;
            _userRepository.Update(checkUserExists);
            var result= await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
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
