using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.GetAllPagination
{
    public class AdminGetAllUserPaginationQueryHandler : IRequestHandler<AdminGetAllUserPaginationQuery, PagedResult<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;   
        public AdminGetAllUserPaginationQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }   
        public async Task<PagedResult<AdminUserDto>> Handle(AdminGetAllUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAllSelectAsync(
               pageNo: request.PageNo,
               pageSize: request.PageSize,
               selector: q => q
                    .OrderByDescending(u => u.CreateDate).ThenBy(m => m.Id)
                   .Select(u => new AdminUserDto
                   {
                       Id = u.Id,
                       Avatar = u.AvatarThumbnail,
                       Background = u.BackgroundThumbnail,
                       DisplayName = u.DisplayName,
                       Email = u.Email,
                       Level = u.Level,
                       PhoneNumber = u.PhoneNumber,
                       Status = u.Status,
                       Roles = u.UserRoleEntities.Select(ur => ur.RoleEntity.RoleName).ToArray()  
                   }),
               cancellation: cancellationToken);

            return users.MapToPagedResult(x => x);
        }
    }
}
