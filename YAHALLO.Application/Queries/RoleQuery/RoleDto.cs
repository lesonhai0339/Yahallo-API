using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.RoleQuery
{
    public class RoleDto : IMapFrom<RoleEntity>
    {
        public string Id { get; set; } = null!;
        public int? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public static RoleDto CreateRoleDto(string id, int? rolecode, string? roledescription, string? rolename) 
        {
            return new RoleDto
            {
                Id = id,
                RoleCode = rolecode,
                RoleName = rolename,
                RoleDescription = roledescription
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoleEntity, RoleDto>();
        }
    }
}
