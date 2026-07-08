using AutoMapper;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.Features.Public.UserSettings
{
    public static class UserSettingsDtoMappingExtension
    {
        public static UserSettingsDto MapToUserSettingsDto(this UserSettingsEntity entity, IMapper mapper)
            => mapper.Map<UserSettingsDto>(entity);
        public static List<UserSettingsDto> MapToUserSettingsDtoToList(this ICollection<UserSettingsEntity> entitiess, IMapper mapper)
            => entitiess.Select(x => x.MapToUserSettingsDto(mapper)).ToList();
    }
}
