using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserDaily;

namespace YAHALLO.Domain.Repositories
{
    public interface IUserDailyActivityRepository : IEFRepository<UserDailyActivityEntity, UserDailyActivityEntity>, IAnalyticsEntity
    {
        Task Increment(string userId, UserDailyType type, CancellationToken cancellation);
    }
}
