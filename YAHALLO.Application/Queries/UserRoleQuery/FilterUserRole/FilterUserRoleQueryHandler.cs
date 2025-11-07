using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Persistence.Data;

namespace YAHALLO.Application.Queries.UserRoleQuery.FilterUserRole
{
    public class FilterUserRoleQueryHandler : IRequestHandler<FilterUserRoleQuery, PagedResult<UserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public FilterUserRoleQueryHandler(
            IUserRoleRepository userRoleRepository, 
            IMapper mapper, 
            IRoleRepository roleRepository, 
            IUserRepository userRepository)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public async Task<PagedResult<UserRoleDto>> Handle(FilterUserRoleQuery request, CancellationToken cancellationToken)
        {
            var query = _userRoleRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (!string.IsNullOrEmpty(request.RoleId))
            {
                query = query.Where(x => x.RoleId == request.RoleId);
            }
            if(request.RoleCode != null)
            {
                query = query.Join(_roleRepository.CreateQueryable(),
                    userrole => userrole.RoleId,
                    role => role.Id,
                    (userrole, role) => new { UserRole = userrole, Role = role })
                    .Where(x => x.Role.RoleCode == request.RoleCode)
                    .Select(x => x.UserRole);
            }
            if (!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Join(_userRepository.CreateQueryable(),
                    userrole => userrole.UserId,
                    user => user.Id,
                    (userrole, user) => new { UserRole = userrole, User = user })
                    .Where(x => x.User.DisplayName != null 
                    ? x.User.DisplayName.Contains(request.UserName) 
                    : (x.User.FirstName + x.User.LastName).Contains(request.UserName))
                    .Select(x => x.UserRole);
            }
            if (!string.IsNullOrEmpty(request.RoleName))
            {
                query = query.Join(_roleRepository.CreateQueryable(),
                   userrole => userrole.RoleId,
                   role => role.Id,
                   (userrole, role) => new { UserRole = userrole, Role = role })
                   .Where(x => x.Role.RoleName.Contains(request.RoleName))
                   .Select(x => x.UserRole);
            }

            var listUserRoleExists = await _userRoleRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(listUserRoleExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy UserRole nào đúng yêu cầu");
            }
            return listUserRoleExists
                .MapToPagedResult(x => x.MapToUserRoleDto(
                x.UserEntity.DisplayName != null ? x.UserEntity.DisplayName : x.UserEntity.FirstName + x.UserEntity.LastName,
                x.RoleEntity.RoleName,_mapper));
        }
    }
}
