using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Persistence.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaAssociateNameRepository : RepositoryBase<MangaAssociateNameEntity, MangaAssociateNameEntity, ApplicationDbContext>, IMangaAssociateNameRepository
    {
        public MangaAssociateNameRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
