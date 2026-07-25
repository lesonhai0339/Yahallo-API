using MediatR;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Admin.User.NewCount
{
    public sealed class AdminCountNewUserQuery: IRequest<PagedResult<AdminCountUserQueryResult>>
    {
        public int PageNo { get; init; } 
        public int PageSize { get; init; }  
        public DateTimeOffset From { get; init; }
        public DateTimeOffset To { get;init; }
        public AdminUserGroupBy GroupBy { get; init; } = AdminUserGroupBy.Day;

    }
    public enum AdminUserGroupBy
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
