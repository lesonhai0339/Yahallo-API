//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : RepositoryBase<NotificationEntity, NotificationEntity, ApplicationDbContext>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
