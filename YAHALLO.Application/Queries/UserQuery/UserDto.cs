using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.UserQuery
{
    public class UserDto : IMapFrom<UserEntity>
    {
        public string Id { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }


        public string? Avatar { get; set; }
        public string? Status { get; set; }
        public string? Level { get; set; }
        public static UserDto CreateUserDto(
            string id,
            string name,
            string email,
            string phone,
            string avatar,
            string status,
            string level)
        {
            return new UserDto
            {
                Id = id,
                DisplayName = name,
                Email = email,
                PhoneNumber = phone,
                Avatar = avatar,
                Status = status,
                Level = level,
            };
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, UserDto>();
        }
    }
}
