//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : RepositoryBase<SubscriptionEntity, SubscriptionEntity, ApplicationDbContext>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
