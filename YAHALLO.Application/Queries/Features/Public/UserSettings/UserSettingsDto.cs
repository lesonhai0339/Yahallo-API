using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.ListView;
using YAHALLO.Domain.Enums.Progress;
using YAHALLO.Domain.Enums.Style;

namespace YAHALLO.Application.Queries.Features.Public.UserSettings
{
    public class UserSettingsDto: IMapFrom<UserSettingsEntity>
    {
        public string Id { get; set; } = string.Empty;
        public string? Language { get; set; }

        public Theme? Theme { get; set; }

        public string? BgImageUrl { get; set; }
        public float? BgOpacity { get; set; }
        public float? BgBlur { get; set; }

        public string? FontFamily { get; set; }
        public int? FontSize { get; set; }
        public string? FontWeight { get; set; }
        public string? FontColor { get; set; }

        public ListView? ListView { get; set; }
        public int? PageSize { get; set; }

        public ProgressReadMode? ProgressReadMode { get; set; }
        public int? RetentionDays { get; set; }
        public int? MaxEntries { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserSettingsEntity, UserSettingsDto>();
        }
    }
}
