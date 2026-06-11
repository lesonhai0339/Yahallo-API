using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserRoleQuery.FilterUserRole
{
    public class FilterUserRoleQueryHandler : IRequestHandler<FilterUserRoleQuery, PagedResult<UserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public FilterUserRoleQueryHandler(
            IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public async Task<PagedResult<UserRoleDto>> Handle(FilterUserRoleQuery request, CancellationToken cancellationToken)
        {
            var query = _userRoleRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);

            if (!string.IsNullOrEmpty(request.UserId))
                query = query.Where(x => x.UserId == request.UserId);

            if (!string.IsNullOrEmpty(request.RoleId))
                query = query.Where(x => x.RoleId == request.RoleId);

            if (request.RoleCode != null)
                query = query.Where(x => x.RoleEntity.RoleCode == request.RoleCode);

            if (!string.IsNullOrEmpty(request.UserName))
                query = query.Where(x => x.UserEntity.DisplayName != null
                    ? x.UserEntity.DisplayName.Contains(request.UserName)
                    : (x.UserEntity.FirstName + x.UserEntity.LastName).Contains(request.UserName));

            if (!string.IsNullOrEmpty(request.RoleName))
                query = query.Where(x => x.RoleEntity.RoleName.Contains(request.RoleName));

            var listUserRoleExists = await _userRoleRepository
                .FindAllSelectAsync(
                    pageNo: request.PageNumber,
                    pageSize: request.PageSize,
                    selector: _ => query
                        .Select(t => new UserRoleDto
                        {
                            UserId = t.UserId,
                            RoleId = t.RoleId,
                            UserName = t.UserEntity.DisplayName ?? t.UserEntity.FirstName + t.UserEntity.LastName,
                            RoleName = t.RoleEntity.RoleName
                        }), 
                    cancellation: cancellationToken);
            if(!listUserRoleExists.Any())
                throw new NotFoundException("Không tìm thấy UserRole nào đúng yêu cầu");

            return listUserRoleExists
                .MapToPagedResult(x => x);
        }
    }
}

