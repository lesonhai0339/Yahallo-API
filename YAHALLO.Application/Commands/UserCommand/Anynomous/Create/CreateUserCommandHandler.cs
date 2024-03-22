using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Services.MailService.Service;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailService _emailServices;
        private readonly ICurrentContextService _context;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUser,
            IUserRoleRepository userRole,
            IRoleRepository roleRepository,
            IEmailService emailService,
            ICurrentContextService context)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _userRoleRepository = userRole;
            _roleRepository = roleRepository;
            _emailServices = emailService;
            _context = context;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await _userRepository.FindAllAsync(x => x.Email.Equals(request.Email) || x.UserName == request.UserName, cancellationToken);
            if (checkExists.Any(x => x.Email == request.Email))
            {
                throw new NotFoundException("Email này đã được sử đụng");
            }
            if (checkExists.Any(x => x.UserName == request.UserName))
            {
                throw new NotFoundException("Tên đăng nhập này đã được sử đụng");
            }
            if (checkExists.Any(x => x.PhoneNumber == request.PhoneNumber))
            {
                throw new NotFoundException("Số điện thoại này đã được sử đụng");
            }
            var User = new UserEntity
            {
                DisplayName = (request.FirstName + " " + request.LastName).ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber ?? null,
                UserName = request.UserName,
                Password = _userRepository.HashPassword(request.Password),
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,
                Status = UserStatus.None,
                Level = UserLevel.One
            };
            _userRepository.Add(User);
            var role = await _roleRepository.FindAsync(x => x.RoleCode == 2, cancellationToken);
            var userRole = new UserRoleEntity { UserId = User.Id, RoleId = role!.Id};
            _userRoleRepository.Add(userRole);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                List<string> listSender= new List<string>() {User.Email };
                var token= _emailServices.GenerateEmailToken(User.Id);
                var route = _context.HttpContext + $"services/confirm-email?token={token}&userid={User.Id}";
                _emailServices.SendEmailWithCSS(new Services.MailService.Models.Message(listSender, "Xác Thực Email",
                    "Yêu cầu xác thực cho việc đăng ký tài khoản", route));
                return $"Một Emaill xac thực đã được gửi đến email {User.Email}. Vui lòng xác nhận để kích hoạt tài khoản";
            }
            else
            {
                return "Đã xảy ra lỗi trong quá trình đăng ký thành viên";
            }
        }
    }
}
