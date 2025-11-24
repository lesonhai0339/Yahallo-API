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
using YAHALLO.Infrastructure.Elastic.Indexes;
using YAHALLO.Infrastructure.Elastic1.Options;

namespace YAHALLO.Infrastructure.Elastic1.Repositories
{
    public class ElasticRepositoryBase<TDomain, TSearch> : IElasticRepository<TDomain, TSearch>
        where TDomain : class
        where TSearch : class
    {
        public readonly IndexNameOptions _indexName;
        public readonly ElasticsearchClient _client;
        public readonly IMapper _mapper;
        public ElasticRepositoryBase(IOptions<IndexNameOptions> options, ElasticsearchClient client, IMapper mapper)
        {
            _indexName = options.Value;
            _client = client;
            _mapper = mapper;
        }
        protected async Task IndexDocumentAsync<TIndex>(TDomain domain, CancellationToken token)
             where TIndex : class
        {
            var doc = _mapper.Map<TIndex>(domain);
            await _client.IndexAsync(doc, i => i.Index(_indexName.IndexName), token);
        }
        public virtual async Task<TSearch> Search(IQuery<TSearch> query, CancellationToken token)
        {
            //https://chatgpt.com/c/691492bc-8608-8324-9639-73782dac327c
            var response = await _client.SearchAsync<TSearch>(s => s
                .Indices(_indexName.IndexName)
                .Query(q =>
                {
                    q.Match()
                    query.Apply(q);
                })
                , token);

            return null;// response.Documents.FirstOrDefault()!;
        }
        public virtual async Task Add(TDomain domain, CancellationToken token)
        {
            var doc = _mapper.Map<TSearch>(domain);

            var result = await _client.IndexAsync(doc, i => i.Index(_indexName.IndexName), token);
        }

        public Task<Action<QueryDescriptor<TSearch>>> Search(TSearch query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
