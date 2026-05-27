//AI generated
using AutoMapper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class ReadingProgressRepository : RepositoryBase<ReadingProgressEntity, ReadingProgressEntity, ApplicationDbContext>, IReadingProgressRepository
    {
        public ReadingProgressRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
