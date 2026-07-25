using MediatR;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.NewCount
{
    public sealed class AdminCountNewUserQueryHandler : IRequestHandler<AdminCountNewUserQuery, PagedResult<AdminCountUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        public AdminCountNewUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<AdminCountUserQueryResult>> Handle(AdminCountNewUserQuery request, CancellationToken cancellationToken)
        {
            var from = request.From.UtcDateTime;       
            var toExclusive = request.To.UtcDateTime;
            var offsetHours = DateTimeHelper.ResolveOffsetHours(null, request.To);

            var query = _userRepository.CreateQueryable();
            query = query.Where(u => u.CreateDate >= from && u.CreateDate < toExclusive);

            var result = request.GroupBy switch
            {
                AdminUserGroupBy.Day => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: _ => query
                    .GroupBy(u => u.CreateDate.AddHours(offsetHours).Date)
                    .Select(i => new AdminCountUserQueryResult 
                    {
                        Day = i.Key.Day,
                        Month = i.Key.Month,
                        Year = i.Key.Year,
                        Count = i.Count()
                    })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day),
                cancellation: cancellationToken),

                AdminUserGroupBy.Month => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: _ => query
                    .GroupBy(u => new {  u.CreateDate.Month, u.CreateDate.Year})
                    .Select(i => 
                        new AdminCountUserQueryResult 
                        {
                            Day = 1,
                            Month = i.Key.Month,
                            Year = i.Key.Year,
                            Count = i.Count()
                        })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month),
                cancellation: cancellationToken),

                AdminUserGroupBy.Year => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: _ => query
                    .GroupBy(u => u.CreateDate.Year)
                    .Select(i => new AdminCountUserQueryResult
                    {
                        Day = 1,
                        Month = 1,
                        Year = i.Key,
                        Count = i.Count()
                    })
                   .OrderBy(x => x.Year),
                cancellation: cancellationToken),

                _ => throw new ArgumentOutOfRangeException(nameof(request.GroupBy), "Invalid CountBy value"),
            };
           
            if (!result.Any())
                throw new NotFoundException("Not found");
            return result.MapToPagedResult(x => x);
        }
    }
} 
