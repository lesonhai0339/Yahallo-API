using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Services.MailService.Service;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.ComfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailServices;
        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailService emailServices)
        {
            _userRepository = userRepository;
            _emailServices = emailServices;
        }

        public async Task<string> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            if (request.UserId == null || request.Token == null)
            {
                throw new NotFoundException("Xác thực thất bại");
            }
            var checkToken = _emailServices.VerifyEmailToken(request.UserId, request.Token);
            if (checkToken == false)
            {
                throw new NotFoundException("Xác thực thất bại");
            }
            var user = await _userRepository
                .FindAsync(x => x.Id == request.UserId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Xác thực thất bại");
            }
            user.EmailConfirm = true;
            _userRepository.Update(user);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Thành công";
            }
            else
            {
                return "Thất bại";
            }
        }
    }
}
