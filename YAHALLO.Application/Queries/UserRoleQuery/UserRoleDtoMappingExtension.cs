using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.UserRoleQuery
{
    public static class UserRoleDtoMappingExtension
    {
        public static UserRoleDto MapToUserRoleDto(this UserRoleEntity entity, IMapper mapper)
            => mapper.Map<UserRoleDto>(entity);
        public static UserRoleDto MapToUserRoleDto(this UserRoleEntity entity,string username, string rolename, IMapper mapper)
        {
            var map = mapper.Map<UserRoleDto>(entity);
            map.UserName = username ?? "";
            map.RoleName = rolename ?? "";
            return map;
        }
        public static List<UserRoleDto> MapToUserRoleDtoToList(this IEnumerable<UserRoleEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToUserRoleDto(mapper)).ToList();
    }
}
