using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Queries.Features.Public.User.DTOs
{
    public static class UserDtoMappingExtension
    {
        //public static UserDto MapToUserDto(this UserEntity Entity, IMapper mapper)=>
        //    mapper.Map<UserDto>(Entity);
        public static UserDto MapToUserDto(this UserEntity Entity, IMapper mapper)
        {
            var map = mapper.Map<UserDto>(Entity);
            map.DisplayName = Entity.DisplayName;
            map.Avatar = Entity.AvatarThumbnail;
            map.Background = Entity.BackgroundThumbnail;
            map.Status = Entity.Status;
            map.Level = Entity.Level;
            return map;
        }
        public static List<UserDto> MapToUserDtoToList(this List<UserEntity> Entities, IMapper mapper) =>
            Entities.Select(x => x.MapToUserDto(mapper)).ToList();
    }
}
