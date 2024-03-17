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

namespace YAHALLO.Application.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRoleRepository _userRoleRepository;
        public CreateUserCommandHandler(
            IUserRepository userRepository, 
            ICurrentUserService currentUser,
            IUserRoleRepository userRole)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
            _userRoleRepository = userRole;
        }   
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var checkExists= await _userRepository.FindAllAsync(x=> x.Email.Equals(request.Email) ,cancellationToken);
            if(checkExists.Any())
            {
                throw new NotFoundException("Have exists user for this email");
            }
            var User = new UserEntity
            {
                DisplayName= (request.FirstName +" "+ request.LastName).ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber ?? null,
                UserName = request.UserName,
                Password = request.Password,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,
                Status = UserStatus.None,
                Level = UserLevel.One
            };
            _userRepository.Add(User);
            var userRole= new UserRoleEntity { UserId = User.Id , RoleId = "1"};
            _userRoleRepository.Add(userRole);
            var result= await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
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
