using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories.Elastic
{
    public interface IElasticRepository<TDomain, TSearch>
    {
        Task<IEnumerable<TDomain>> Search(IElasticQueryBuilder<TDomain> query, CancellationToken token);
        Task Add(TDomain domain, CancellationToken token);
        Task<bool> Update(string docId, TDomain domain, CancellationToken token);
        Task<bool> Update(string docId, Dictionary<string, object> keyValuePair, CancellationToken token);
        Task<bool> Delete(string docId, CancellationToken token);
    }
}
