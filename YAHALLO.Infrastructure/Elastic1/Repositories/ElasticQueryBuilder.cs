using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Elastic;

namespace YAHALLO.Infrastructure.Elastic1.Repositories
{
    public class ElasticQueryBuilder<TIndex> : IElasticQueryBuilder<TIndex>
        where TIndex : class
    {
        private readonly List<Func<QueryDescriptor<TIndex>, QueryDescriptor<TIndex>>> _filters = new();
        private readonly ElasticsearchClient _client;
        private readonly string _index;

        public ElasticQueryBuilder(ElasticsearchClient client)
        {
            _client = client;
            _index = typeof(TIndex).Name.ToLowerInvariant();
        }

        public async Task<IEnumerable<TIndex>> SearchAsync(CancellationToken token = default)
        {
            QueryDescriptor<TIndex> query = new QueryDescriptor<TIndex>();

            foreach (var filter in _filters)
                query = filter(query);

            var response = await _client.SearchAsync<TIndex>(s => s
                .Indices(_index)
                .Query(query),
                token);

            return response.Documents;
        }
        public async Task<IEnumerable<TIndex>> ExecuteAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();

        }
        public async Task<bool> AddAsync(TIndex index, CancellationToken token)
        {
            var response = await _client.IndexAsync(index, i => i
            .Index(_index), token);

            return response.IsValidResponse;
        }
        public IElasticQueryBuilder<TIndex> Match(Expression<Func<TIndex, object>> field, string value)
        {
            _filters.Add(q => q.Match(m => m.Field(field!).Query(value)));
            return this;
        }
        public IElasticQueryBuilder<TIndex> Or(Expression<Func<TIndex, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IElasticQueryBuilder<TIndex> Term(Expression<Func<TIndex, object>> field, object value)
        {
            _filters.Add(m => m.Term(t => t.Field(field!).Value(value.ToString()!)));
            return this;
        }

        public async Task Update(TIndex doc, CancellationToken token)
        {
            throw new NotImplementedException();

            //var items = await SearchAsync(token);
            //foreach(var item in items)
            //{
            //    var result = await _client.UpdateAsync<TIndex, TIndex>(_index, docId , u => u.Doc(doc), token);
            //}
        }
    }
}
