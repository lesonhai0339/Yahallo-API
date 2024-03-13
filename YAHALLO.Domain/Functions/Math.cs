using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Domain.Functions
{
    public static class Math
    {
        public static double AverageRating(IEnumerable<MangaRatingEntity> Ratings)
        {
            var TotalScore= Ratings.Sum(x=> x.Rating);
            var TotalUser = Ratings.Count();
            return TotalScore * 1.0 / TotalUser;
        }
    }
}
