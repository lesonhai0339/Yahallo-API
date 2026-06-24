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

        public string? Language { get; set; }   
        
        public Theme Theme { get; set; }

        //background(website)
        public string? BgImageUrl { get; set; }  
        public float? BgOpacity { get; set; }   
        public float? BgBlur { get; set; }

        //Font
        public string? FontFamily { get; set; }
        public int? FontSize { get; set; }
        public string? FontWeight { get; set; } 
        public string? FontColor { get; set; }

        //List view
        public ListView? ListView { get; set; }
        public int? PageSize { get; set; }  

        public ProgressReadMode ProgressReadMode { get; set; }
        public int RetentionDays { get; set; } = 1;
        public int MaxEntries { get; set; } = 10;
    }
}
