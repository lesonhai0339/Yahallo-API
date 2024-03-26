using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.UserRoleQuery
{
    public class UserRoleDto : IMapFrom<UserRoleEntity>
    {
        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }
        public static UserRoleDto CreateUserRoleDto(string userrid, string? username, string roleid, string? rolename)
        {
            return new UserRoleDto
            {
                UserId = userrid,
                RoleId = roleid,
                UserName = username,
                RoleName = rolename
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRoleEntity, UserRoleDto>();
        }
    }
}
