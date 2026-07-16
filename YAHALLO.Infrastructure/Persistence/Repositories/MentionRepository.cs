using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MentionRepository : RepositoryBase<MentionEntity, MentionEntity, ApplicationDbContext>, IMentionRepository
    {
        public MentionRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
