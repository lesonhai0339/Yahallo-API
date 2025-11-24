using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Persistence.Data;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class MangaRatingRepository : RepositoryBase<MangaRatingEntity, MangaRatingEntity, ApplicationDbContext>, IMangaRatingRepository
    {
        public MangaRatingRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public double AverageRating(IEnumerable<MangaRatingEntity> Ratings)
        {
            var TotalScore = Ratings.Sum(x => x.Rating);
            var TotalUser = Ratings.Count();
            return TotalScore * 1.0 / TotalUser;
        }
    }
}
