using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.DTOs;
using YAHALLO.Domain.Enums.ListView;
using YAHALLO.Domain.Enums.Progress;
using YAHALLO.Domain.Enums.Style;
using YAHALLO.Domain.Enums.Theme;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Update
{
    public class UpdateUserSettingsCommand: IRequest<UpdateUserSettingResult>
    {
        public string? Language { get; set; } = null;

        public Theme? Theme { get; set; } = null;

        public Transition? Transition { get; set; }  
        public FileUploadInfo? BgImage { get; set; } = null;
        public float? BgOpacity { get; set; } = null;
        public float? BgBlur { get; set; } = null;

        public string? FontFamily { get; set; } = null;
        public int? FontSize { get; set; } = null;
        public string? FontWeight { get; set; } = null;
        public string? FontColor { get; set; } = null;

        public ListView? ListView { get; set; } = null;
        public int? PageSize { get; set; } = null;

        public ProgressReadMode? ProgressReadMode { get; set; } = null;
        public int? RetentionDays { get; set; } = null;
        public int? MaxEntries { get; set; } = null;
    }
    public record UpdateUserSettingResult(string? UploadUrl = null, string? AccessUrl = null);
}
