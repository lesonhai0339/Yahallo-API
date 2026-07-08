using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Admin.Role
{
    public class AdminRoleDto : IMapFrom<RoleEntity>
    {
        public string Id { get; set; } = null!;
        public int? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoleEntity, AdminRoleDto>();
        }
    }
}
