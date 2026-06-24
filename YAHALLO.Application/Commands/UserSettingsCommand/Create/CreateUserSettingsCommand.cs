using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.ListView;
using YAHALLO.Domain.Enums.Progress;
using YAHALLO.Domain.Enums.Style;

namespace YAHALLO.Application.Commands.UserSettingsCommand.Create
{
    public class CreateUserSettingsCommand: IRequest<string>
    {
        public string? Language { get; set; }

        public Theme Theme { get; set; }

        public IFormFile? BgImage { get; set; }
        public float? BgOpacity { get; set; }
        public float? BgBlur { get; set; }

        public string? FontFamily { get; set; }
        public int? FontSize { get; set; }
        public string? FontWeight { get; set; }
        public string? FontColor { get; set; }

        public ListView? ListView { get; set; }
        public int? PageSize { get; set; }

        public ProgressReadMode ProgressReadMode { get; set; }
        public int RetentionDays { get; set; } = 1;
        public int MaxEntries { get; set; } = 10;
    }
}
