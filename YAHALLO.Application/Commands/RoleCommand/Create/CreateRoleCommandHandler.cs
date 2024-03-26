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

namespace YAHALLO.Application.Commands.RoleCommand.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUserService _currentUser;
            public CreateRoleCommandHandler(IRoleRepository roleRepository,ICurrentUserService currentUser)
        {
            _roleRepository = roleRepository;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var query = _roleRepository.IQueryableHandlerEqual(request);
            var checkCodeExist = await _roleRepository.FindAsync(x=> x.RoleCode == request.RoleCode, cancellationToken);
            if (checkCodeExist != null)
            {
                throw new NotFoundException($"Đã tồn tại rolecode trên");
            }
            var checkExists = await _roleRepository.FindAsync(query, cancellationToken);
            if(checkExists != null)
            {
                throw new NotFoundException("Đã tồn tại role với các thông tin trên");
            }
            var newRole = new RoleEntity
            {
                RoleCode = request.RoleCode,
                RoleDescription = request.RoleDescription,
                RoleName = request.RoleName,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,
            };
            _roleRepository.Add(newRole);   
            var result= await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
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
