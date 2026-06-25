using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.ListView;
using YAHALLO.Domain.Enums.Progress;
using YAHALLO.Domain.Enums.Style;

namespace YAHALLO.Domain.Entities
{
    public class UserSettingsEntity: BaseEntity
    {
        public required string UserId { get;set; }
        public virtual UserEntity? User { get; set; }

        public string? Language { get; set; } = "vi";

        public Theme Theme { get; set; } = Theme.Dark;

        //background(website)
        public string? BgImageUrl { get; set; }  = string.Empty;
        public float? BgOpacity { get; set; } = 0;
        public float? BgBlur { get; set; } = 0;

        //Font
        public string? FontFamily { get; set; } = string.Empty;
        public int? FontSize { get; set; } = 16;
        public string? FontWeight { get; set; } = "400";
        public string? FontColor { get; set; } = "#000000";

        //List view
        public ListView? ListView { get; set; } = Enums.ListView.ListView.List;
        public int? PageSize { get; set; } = 10;

        public ProgressReadMode ProgressReadMode { get; set; } = ProgressReadMode.Off;
        public int RetentionDays { get; set; } = 1;
        public int MaxEntries { get; set; } = 10;
        public void ResetToDefault()
        {
            this.Language = "vi";
            this.Theme = Theme.Dark;
            this.BgImageUrl = string.Empty;
            this.BgOpacity = 0;
            this.BgBlur = 0;
            this.FontFamily = string.Empty;
            this.FontSize = 16;
            this.FontWeight = "400";
            this.FontColor = "#000000";
            this.ListView = Enums.ListView.ListView.List;
            this.PageSize = 10; 
            this.ProgressReadMode = ProgressReadMode.Off;   
            this.RetentionDays = 1;
            this.MaxEntries = 10;   
        }
    }
}
