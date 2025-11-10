using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IElasticRepository<TDomain, TSearch, TQuery>
    {
        Task<TSearch> Search(TQuery query, CancellationToken token);
        Task Add(TDomain domain, CancellationToken token);
    }
}
