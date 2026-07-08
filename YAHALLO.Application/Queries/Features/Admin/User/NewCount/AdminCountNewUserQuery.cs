using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.User.NewCount
{
    public sealed class AdminCountNewUserQuery: IRequest<PagedResult<AdminCountUserQueryResult>>
    {
        public int PageNo { get; init; } 
        public int PageSize { get; init; }  
        public DateTime From { get; init; }
        public DateTime To { get;init; }
        public AdminUserCountBy CountBy { get; init; } = AdminUserCountBy.Day;
        public int TimeZoneOffset { get; init; } = 0;

    }
    public enum AdminUserCountBy
    {
        Day, 
        Month,
        Year
    }
    public record AdminCountUserQueryResult
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
