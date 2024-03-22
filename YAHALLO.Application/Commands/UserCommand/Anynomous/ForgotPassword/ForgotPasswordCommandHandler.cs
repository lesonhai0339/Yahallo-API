using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Models;
using YAHALLO.Application.Services.MailService.Service;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public ForgotPasswordCommandHandler(
            IUserRepository userRepository,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var checkUserExists = await _userRepository
                .FindAsync(x => x.Email == request.Email && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkUserExists == null)
            {
                throw new NotFoundException($"Không tìm thấy thành viên với Email {request.Email}");
            }
            var newPassword = Guid.NewGuid().ToString("N").Substring(0, 6);
            checkUserExists.Password = _userRepository.HashPassword(newPassword);
            _userRepository.Update(checkUserExists);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                var To = new List<string>() { checkUserExists.Email };
                var emailsender = new Message(To, "Quên mật khẩu", $"Mật khẩu mới của bạn là : {newPassword}", null);
                _emailService.SendEmail(emailsender);
                return $"Mật khẩu mới đã được gửi tới Email {checkUserExists.Email}";
            }
            else
            {
                return "Đã xảy ra lỗi";
            }

        }
    }
}
