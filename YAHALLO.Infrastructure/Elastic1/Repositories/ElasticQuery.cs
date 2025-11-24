using Elastic.Clients.Elasticsearch.QueryDsl;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Elastic;

namespace YAHALLO.Infrastructure.Elastic1.Repositories
{
    public class ElasticQuery<TSearch>: IQuery<TSearch>
    {
        private readonly Action<QueryDescriptor<TSearch>> _action;

        public ElasticQuery(Action<QueryDescriptor<TSearch>> action)
        {
            this._action = action;
        }
        public void Apply(object queryContext)
        {
            var descriptor = (QueryDescriptor<TSearch>)queryContext;
            _action(descriptor);
        }
    }
}
