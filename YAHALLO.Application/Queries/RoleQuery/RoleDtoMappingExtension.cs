using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.RoleQuery
{
    public static class RoleDtoMappingExtension
    {
        public static RoleDto MapToRoleDto(this RoleEntity entity, IMapper mapper)
            => mapper.Map<RoleDto>(entity);
        public static List<RoleDto> MapToRoleDtoToList(this IEnumerable<RoleEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapToRoleDto(mapper)).ToList();
    }
}
