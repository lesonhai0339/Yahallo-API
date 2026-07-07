using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories
{
    public interface IUserMangaDailyReadRepository:IEFRepository<UserMangaDailyReadEntity, UserMangaDailyReadEntity>, IAnalyticsEntity
    {
    }
}
