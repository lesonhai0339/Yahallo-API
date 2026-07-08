using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.UserRole
{
    public class AdminUserRoleDto : IMapFrom<UserRoleEntity>
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }
        public int RoleCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRoleEntity, AdminUserRoleDto>();
        }
    }
}
