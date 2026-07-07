using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaDaily;
using YAHALLO.Domain.Enums.UserDaily;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class UserDailyActivityRepository : RepositoryBase<UserDailyActivityEntity, UserDailyActivityEntity, ApplicationDbContext>, IUserDailyActivityRepository
    {
        public UserDailyActivityRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task Increment(string userId, UserDailyType type, CancellationToken cancellation)
        {
            var today = DateTime.UtcNow.Date;
            var now = DateTime.UtcNow;

            var daily = await FindAsync(x => x.UserId == userId && x.Date == today, cancellation);
            if (daily == null)
            {
                daily = new UserDailyActivityEntity
                {
                    UserId = userId,
                    Date = today,
                    LastActivityTime = now,
                    FirstActivityTime = now,
                    ActiveMinutes = 0,
                    CommentCount = type == UserDailyType.Comment ? 1 : 0,
                    ChapterCount = type == UserDailyType.Read ? 1 : 0,
                };
                Add(daily);
            }
            else
            {
                if (type == UserDailyType.Activity && daily.LastActivityTime > now.AddMinutes(-2.5))
                    return;

                daily.ActiveMinutes += type == UserDailyType.Activity ? 3 : 0;
                daily.CommentCount += type == UserDailyType.Comment ? 1 : 0;
                daily.ChapterCount += type == UserDailyType.Read ? 1 : 0;
                daily.LastActivityTime = now;
                Update(daily);
            }
        }
    }
}
