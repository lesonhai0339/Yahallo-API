using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IElasticRepository<TDomain, TSearch>
    {
        Task<TSearch> Search(IQuery<TSearch> query, CancellationToken token);
        Task Add(TDomain domain, CancellationToken token);
    }
}
