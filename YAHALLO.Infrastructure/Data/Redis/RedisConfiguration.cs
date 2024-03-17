using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Infrastructure.Data.Redis
{
    public class RedisConfiguration<TDomain>
        where TDomain: class
    {
        public virtual TDomain? GetCache(string key)
        {
            return null;
        }
    }
}
