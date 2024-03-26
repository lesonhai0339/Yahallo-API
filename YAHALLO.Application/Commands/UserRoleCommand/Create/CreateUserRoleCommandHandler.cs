using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserRoleCommand.Create
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, string>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateUserRoleCommandHandler(IUserRoleRepository userRole, ICurrentUserService currentUser)
        {
            _userRoleRepository = userRole;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var query = _userRoleRepository.IQueryableHandlerEqual(request);
            var checkExist = await _userRoleRepository
                .FindAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, query, cancellationToken);
            if (checkExist != null)
            {
                throw new NotFoundException("Thành viên đã có role này");
            }
            var newUserRole = new UserRoleEntity
            {
                UserId = request.UserId,
                RoleId = request.RoleId,
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUser.UserId
            };
            _userRoleRepository.Add(newUserRole);
            var resut = await _userRoleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(resut > 0)
            {
                return "Tạo thành công";
            }
            else
            {
                return "Tạo thất bại";
            }
        }
    }
}
