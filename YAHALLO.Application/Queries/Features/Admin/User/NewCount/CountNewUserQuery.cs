using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.User.NewCount
{
    public sealed class CountNewUserQuery: IRequest<PagedResult<CountUserQueryResult>>
    {
        public int PageNo { get; init; } 
        public int PageSize { get; init; }  
        public DateTime From { get; init; }
        public DateTime To { get;init; }
        public UserCountBy CountBy { get; init; } = UserCountBy.Day;
        public int TimeZoneOffset { get; init; } = 0;

    }
    public enum UserCountBy
    {
        Day, 
        Month,
        Year
    }
    public record CountUserQueryResult
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
