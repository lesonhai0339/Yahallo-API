using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Interfaces
{
    public interface IBackgroundTaskQueue
    {
        void EnqueueNewChapterNotifications(string mangaId, string chapterId);
    }
}
