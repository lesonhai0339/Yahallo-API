using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Elastic.Repositories
{
    public class UserSearchRepository : ElasticsearchRepository<UserEntity, UserEntity>
    {
        public UserSearchRepository(IMapper mapper) : base(mapper)
        {
        }
    }
}
