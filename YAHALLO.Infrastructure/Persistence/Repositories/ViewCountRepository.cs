using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class ViewCountRepository : RepositoryBase<ViewCountEntity, ViewCountEntity, ApplicationDbContext>, IViewCountRepository
    {
        public ViewCountRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
