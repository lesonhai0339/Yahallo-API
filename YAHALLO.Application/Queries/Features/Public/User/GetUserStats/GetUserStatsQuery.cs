using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserDaily;

namespace YAHALLO.Application.Queries.Features.Public.User.GetUserStats
{
    public class GetUserStatsQuery: IRequest<List<GetUserStatsResult>>
    {
        public string UserId { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public UserDailyFilterBy FilterBy { get; set; }
    }
    public record GetUserStatsResult
    {
        public int CommentCount { get; set; }   
        public int ChapterCount { get; set; }   
        public int ActivityTime { get; set; }
        public int Day {  get; set; }   
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
