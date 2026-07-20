//AI generated
using YAHALLO.Domain.Entities;

namespace YAHALLO.Domain.Repositories
{
    public interface INotificationRepository : IEFRepository<NotificationEntity, NotificationEntity>
    {
        Task<IPagedResult<NotifRow>> FeedAsync(string uid, int pageNo, int PageSize, CancellationToken cancellationToken);
    }
}
