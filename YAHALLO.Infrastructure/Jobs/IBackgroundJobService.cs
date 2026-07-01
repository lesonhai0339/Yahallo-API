//AI generated
namespace YAHALLO.Infrastructure.Jobs
{
    public interface IBackgroundJobService
    {
        /// <summary>Dispatch new-chapter notifications to all followers of a manga.</summary>
        Task DispatchNewChapterNotificationsAsync(string mangaId, string chapterId, CancellationToken cancellationToken = default);

        /// <summary>Hard-delete records that were soft-deleted more than <paramref name="olderThanDays"/> days ago.</summary>
        Task CleanupSoftDeletedRecordsAsync(int olderThanDays = 30, CancellationToken cancellationToken = default);

        /// <summary>Expire subscriptions that have passed their end date.</summary>
        Task ExpireSubscriptionsAsync(CancellationToken cancellationToken = default);
        Task CleanupExpiredTokensAsync(CancellationToken cancellationToken = default);
    }
}
