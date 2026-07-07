using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class UserDailyActivityEntity:BaseEntity
    {
        public int ChapterCount { get; set; }   
        public int CommentCount { get; set; }   
        public int SearchCount { get; set; }    
        public int ActiveMinutes { get; set; }
        public DateTime Date { get; set;  }
        public DateTime LastActivityTime { get; set;  }
        public DateTime FirstActivityTime { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; } = null!;
        public virtual UserEntity? User { get;set;  }
    }
}
