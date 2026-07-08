using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YAHALLO.Domain.Enums.UserDaily;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.User.GetUserStats
{
    public class GetUserStatsQueryHandler : IRequestHandler<GetUserStatsQuery, List<GetUserStatsResult>>
    {
        private readonly IUserDailyActivityRepository _userDailyActivityRepository;
        public GetUserStatsQueryHandler(IUserDailyActivityRepository userDailyActivityRepository)
        {
            _userDailyActivityRepository = userDailyActivityRepository; 
        }
        public async Task<List<GetUserStatsResult>> Handle(GetUserStatsQuery request, CancellationToken cancellationToken)
        {
            var from = request.From.Date;
            var to = request.To.Date;

            var query = _userDailyActivityRepository.CreateQueryable();
            query = query.Where(x => x.Date >= from && x.Date <= to);

            var result = request.FilterBy switch
            {
                UserDailyFilterBy.Day => await _userDailyActivityRepository.FindAllSelectAsync(
                    _ => query
                    .GroupBy(x => x.Date.Date)
                    .Select(x => new GetUserStatsResult
                    {
                        ActivityTime = x.Sum(_ => _.ActiveMinutes),
                        ChapterCount = x.Sum(_ => _.ChapterCount),
                        CommentCount = x.Sum(_ => _.CommentCount),  
                        Day = x.Key.Day,
                        Month = x.Key.Month,
                        Year = x.Key.Year,  
                    })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day),
                    cancellationToken),

                UserDailyFilterBy.Month => await _userDailyActivityRepository.FindAllSelectAsync(
                   _ => query
                   .GroupBy(x => new { Month = x.Date.Month, Year = x.Date.Year })
                   .Select(x => new GetUserStatsResult
                   {
                       ActivityTime = x.Sum(_ => _.ActiveMinutes),
                       ChapterCount = x.Sum(_ => _.ChapterCount),
                       CommentCount = x.Sum(_ => _.CommentCount),
                       Day = 1,
                       Month = x.Key.Month,
                       Year = x.Key.Year,
                   })
                   .OrderBy(x => x.Year).ThenBy(x => x.Month),
                   cancellationToken),

                UserDailyFilterBy.Year => await _userDailyActivityRepository.FindAllSelectAsync(
                   _ => query
                   .GroupBy(x => x.Date.Year)
                   .Select(x => new GetUserStatsResult
                   {
                       ActivityTime = x.Sum(_ => _.ActiveMinutes),
                       ChapterCount = x.Sum(_ => _.ChapterCount),
                       CommentCount = x.Sum(_ => _.CommentCount),
                       Day = 1,
                       Month = 1,
                       Year = x.Key,
                   })
                   .OrderBy(x => x.Year),
                   cancellationToken),

                _ => throw new UnsupportedContentTypeException(nameof(GetUserStatsQuery)),
            };

            return result;
        }
    }
}
