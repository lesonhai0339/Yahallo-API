using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Infrastructure.Elastic1.Options;

namespace YAHALLO.Infrastructure.Elastic1.Repositories
{
    public class ElasticRepositoryBase<TDomain, TSearch , TQuery> : IElasticRepository<TDomain, TSearch, TQuery>
        where TDomain : class
        where TSearch : class
        where TQuery : Action<QueryDescriptor<TSearch>>
    {
        private readonly IndexNameOptions _indexName;
        private readonly ElasticsearchClient _client;
        private readonly IMapper _mapper;
        public ElasticRepositoryBase(IOptions<IndexNameOptions> options, ElasticsearchClient client, IMapper mapper)
        {
            _indexName = options.Value;
            _client = client;
            _mapper = mapper;
        }
        public virtual async Task<TSearch> Search(Action<QueryDescriptor<TSearch>> queryAction, CancellationToken token)
        {
            var response =   await _client.SearchAsync<TSearch>(s => s
                .Indices(_indexName.IndexName)
                .Query(queryAction)
                , token);

            return response.Documents.FirstOrDefault()!;
        }
        public virtual async Task Add(TDomain domain, CancellationToken token)
        {
            var doc = _mapper.Map<TSearch>(domain);

            await _client.IndexAsync(doc, i => i.Index(_indexName.IndexName), token);
        }

        public Task<Action<QueryDescriptor<TSearch>>> Search(TSearch query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<TSearch> Search(TQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
