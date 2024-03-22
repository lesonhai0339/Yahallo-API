using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            Func<IQueryable<UserEntity>, IQueryable<UserEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                if (!string.IsNullOrEmpty(request.Id))
                {
                    query = query.Where(x => x.Id == request.Id);
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(x => x.Email == request.Email);
                }
                return query;
            };

            var checkUserExists= await _userRepository
                .FindAsync(options,cancellationToken); 
            if(checkUserExists == null)
            {
                throw new NotFoundException($"Không tìm thấy thành viên");
            }
            var checkPassword = _userRepository.VerifyPassword(checkUserExists.Password, request.OldPassword!);
            if(checkPassword == false)
            {
                throw new NotFoundException($"Mật khẩu cũ không chính xác");
            }
            checkUserExists.Password = _userRepository.HashPassword(request.NewPassword!);
            _userRepository.Update(checkUserExists);
            var result= await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return "Thay đổi mật khẩu thành công";
            }
            else
            {
                return "Đã xảy ra lỗi";
            }
        }
    }
}
