using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteUserCommandHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var checkUserExist = await _userRepository.FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkUserExist == null)
            {
                throw new NotFoundException("KHông tìm thấy thành viên");
            }
            checkUserExist.DeleteDate = DateTime.Now;
            checkUserExist.IdUserDelete = _currentUser.UserId;
            _userRepository.Update(checkUserExist);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
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
