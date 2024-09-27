using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.RecommendPassword
{
    public class RecommendPasswordCommandHandler : IRequestHandler<RecommendPasswordCommand, ResponseResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOldPasswordRepository userOldPasswordRepository;
        public RecommendPasswordCommandHandler(IUserRepository userRepository, IUserOldPasswordRepository userOldPasswordRepository)
        {
            _userRepository = userRepository;
            this.userOldPasswordRepository = userOldPasswordRepository;
        }

        public async Task<ResponseResult<string>> Handle(RecommendPasswordCommand request, CancellationToken cancellationToken)
        {
            var checkUserExist= await _userRepository.FindAsync(x=> x.UserName == request.UserName || x.Email == request.Email, cancellationToken);
            if(checkUserExist == null) 
            {
                throw new NotFoundException("Không tồn tại thành viên");
            }
            if(!string.IsNullOrEmpty(checkUserExist.IdUserDelete) && checkUserExist.DeleteDate.HasValue)
            {
                throw new NotFoundException("Thành viên này đã bị khóa");
            }
            var listOldPassword = checkUserExist.OldPasswords.OldPasswordList();
            listOldPassword = listOldPassword.Select(x => x.Substring(0 , x.Length /2 )).ToList();
            return new ResponseResult<string>(listOldPassword);
        }
    }
}
