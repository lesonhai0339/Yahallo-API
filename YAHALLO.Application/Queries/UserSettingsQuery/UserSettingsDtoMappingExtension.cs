using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.UserSettingsQuery
{
    public static class UserSettingsDtoMappingExtension
    {
        public static UserSettingsDto MapToUserSettingsDto(this UserSettingsEntity entity, IMapper mapper)
            => mapper.Map<UserSettingsDto>(entity);
        public static List<UserSettingsDto> MapToUserSettingsDtoToList(this ICollection<UserSettingsEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToUserSettingsDto(mapper)).ToList();
    }
}
