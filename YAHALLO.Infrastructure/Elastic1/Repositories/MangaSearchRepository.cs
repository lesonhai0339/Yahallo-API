using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Infrastructure.Elastic.DTOs;
using YAHALLO.Infrastructure.Elastic.Indexes;
using YAHALLO.Infrastructure.Elastic.QueryBuilder;
using YAHALLO.Infrastructure.Elastic1.Options;
using YAHALLO.Infrastructure.Elastic1.Repositories;

namespace YAHALLO.Infrastructure.Elastic.Repositories
{
    public class MangaSearchRepository : ElasticRepositoryBase<MangaEntity, MangaEntity>, IMangaSearchRepository
    {
        public MangaSearchRepository(IOptions<IndexNameOptions> options, ElasticsearchClient client, IMapper mapper) : base(options, client, mapper)
        {
        }
        public override async Task Add(MangaEntity domain, CancellationToken token)
        {
            await IndexDocumentAsync<MangaIndex>(domain, token);
        }
    }
}
