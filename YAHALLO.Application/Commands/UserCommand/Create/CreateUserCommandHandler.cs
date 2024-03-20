using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        public CreateUserCommandHandler(
            IUserRepository userRepository,
            ICurrentUserService currentUser,
            IUserRoleRepository userRole,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _userRoleRepository = userRole;
            _roleRepository = roleRepository;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkExists = await _userRepository.FindAllAsync(x => x.Email.Equals(request.Email) || x.UserName == request.UserName, cancellationToken);
            if(checkExists.Any(x=> x.Email == request.Email))
            {
                throw new NotFoundException("Email này đã được sử đụng");
            }
            if (checkExists.Any(x=> x.UserName == request.UserName))
            {
                throw new NotFoundException("Tên đăng nhập này đã được sử đụng");
            }
            if(checkExists.Any(x=> x.PhoneNumber == request.PhoneNumber))
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
            var userRole = new UserRoleEntity { UserId = User.Id, RoleId = role?.Id ?? "6a8225cb691c49c799f68796a5148cd1" };
            _userRoleRepository.Add(userRole);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Create Successfully";
            }
            else
            {
                return "Create Failed";
            }
        }
    }
}
