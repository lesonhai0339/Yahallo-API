using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.Features.Admin.User
{
    public class AdminUserDto : IMapFrom<UserEntity>
    {
        public string Id { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string? Background { get; set; }
        public UserStatus? Status { get; set; }
        public UserLevel? Level { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, AdminUserDto>();
        }
    }
}
