using Elastic.Clients.Elasticsearch.QueryDsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Infrastructure.Elastic.DTOs;
using YAHALLO.Infrastructure.Elastic.Indexes;
using Nest;
using MatchQuery = Nest.MatchQuery;


namespace YAHALLO.Infrastructure.Elastic.QueryBuilder
{
    public static class MangaQueryBuilder
    {
        public static QueryContainer Build(MangaSearchRequest request)
        {
            QueryContainer query = new QueryContainer();

            if (!string.IsNullOrEmpty(request.MangaName))
            {
                query &= new MatchQuery
                {
                    Field = Infer.Field<MangaIndex>(f => f.Name),
                    Query = request.MangaName
                };
            }

            return query;
        }
    }
}
