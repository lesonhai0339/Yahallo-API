using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Infrastructure.Elastic.Repositories
{
    public class ElasticsearchRepository<TDomain, TPersistence>: IElasticsearchRepository<TDomain, TPersistence>
    where TPersistence : class, TDomain
    where TDomain : class
    {
        private readonly IMapper _mapper;
        public ElasticsearchRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
