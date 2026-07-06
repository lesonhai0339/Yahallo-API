using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Infrastructure.Jobs
{
    public class BackgroundTaskQueue: IBackgroundTaskQueue
    {
        private readonly IBackgroundJobClient _client;
        public BackgroundTaskQueue(IBackgroundJobClient client)
        {
            _client = client;   
        }
        public void EnqueueNewChapterNotifications(string mangaId, string chapterId)
        => _client.Enqueue<IBackgroundJobService>(
            s => s.DispatchNewChapterNotificationsAsync(mangaId, chapterId, CancellationToken.None));
    }
}
