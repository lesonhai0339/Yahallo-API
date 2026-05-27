//AI generated
using Microsoft.Extensions.Logging;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.NotificationEnums;
using YAHALLO.Domain.Enums.SubscriptionEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Infrastructure.Jobs
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly IFollowRepository _followRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BackgroundJobService> _logger;

        public BackgroundJobService(
            IFollowRepository followRepository,
            INotificationRepository notificationRepository,
            IMangaRepository mangaRepository,
            IChapterRepository chapterRepository,
            ISubscriptionRepository subscriptionRepository,
            IUnitOfWork unitOfWork,
            ILogger<BackgroundJobService> logger)
        {
            _followRepository = followRepository;
            _notificationRepository = notificationRepository;
            _mangaRepository = mangaRepository;
            _chapterRepository = chapterRepository;
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task DispatchNewChapterNotificationsAsync(string mangaId, string chapterId, CancellationToken cancellationToken = default)
        {
            var manga = await _mangaRepository.FindAsync(x => x.Id == mangaId, cancellationToken);
            if (manga is null) return;

            var chapter = await _chapterRepository.FindAsync(x => x.Id == chapterId, cancellationToken);
            if (chapter is null) return;

            var followers = await _followRepository.FindAllAsync(
                x => x.MangaId == mangaId && string.IsNullOrEmpty(x.IdUserDelete),
                cancellationToken);

            foreach (var follow in followers)
            {
                var notification = new NotificationEntity
                {
                    UserId = follow.UserId!,
                    Title = $"Chapter mới: {manga.Name}",
                    Message = $"Chapter {chapter.Title} vừa được cập nhật!",
                    Type = NotificationType.NewChapter,
                    Status = NotificationStatus.Unread,
                    ReferenceId = chapterId,
                    CreatedAt = DateTime.Now
                };
                _notificationRepository.Add(notification);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Dispatched {Count} notifications for manga {MangaId} chapter {ChapterId}", followers.Count, mangaId, chapterId);
        }

        public async Task CleanupSoftDeletedRecordsAsync(int olderThanDays = 30, CancellationToken cancellationToken = default)
        {
            var cutoff = DateTime.Now.AddDays(-olderThanDays);
            var oldNotifications = await _notificationRepository.FindAllAsync(
                x => x.DeleteDate.HasValue && x.DeleteDate < cutoff,
                cancellationToken);

            foreach (var item in oldNotifications)
                _notificationRepository.Remove(item);

            var removed = await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Cleanup removed {Count} soft-deleted notifications older than {Days} days", removed, olderThanDays);
        }

        public async Task ExpireSubscriptionsAsync(CancellationToken cancellationToken = default)
        {
            var expiredSubs = await _subscriptionRepository.FindAllAsync(
                x => x.Status == SubscriptionStatus.Active && x.EndDate < DateTime.Now,
                cancellationToken);

            foreach (var sub in expiredSubs)
            {
                sub.Status = SubscriptionStatus.Expired;
                _subscriptionRepository.Update(sub);
            }

            var updated = await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Expired {Count} subscriptions", updated);
        }
    }
}
