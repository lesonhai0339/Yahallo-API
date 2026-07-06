using MediatR;
using System.Linq;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.GetNewUserContByDate
{
    public class CountNewUserQueryHandler : IRequestHandler<CountNewUserQuery, PagedResult<CountUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;
        public CountNewUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<CountUserQueryResult>> Handle(CountNewUserQuery request, CancellationToken cancellationToken)
        {
            var result = request.CountBy switch
            {
                UserCountBy.Day => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(u => u.CreateDate >= request.From && u.CreateDate <= request.To.AddDays(1))
                    .GroupBy(u => u.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Date)
                    .Select(i => new CountUserQueryResult 
                    {
                        Day = i.Key.Day,
                        Month = i.Key.Month,
                        Year = i.Key.Year,
                        Count = i.Count()
                    })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day),
                cancellation: cancellationToken),

                UserCountBy.Month => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(u => u.CreateDate >= request.From && u.CreateDate <= request.To)
                    .GroupBy(u => new {  Month = u.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Month, Year = u.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Year})
                    .Select(i => 
                        new CountUserQueryResult 
                        {
                            Day = 1,
                            Month = i.Key.Month,
                            Year = i.Key.Year,
                            Count = i.Count()
                        })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month),
                cancellation: cancellationToken),

                UserCountBy.Year => await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(u => u.CreateDate >= request.From && u.CreateDate <= request.To)
                    .GroupBy(u => u.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Year)
                    .Select(i => new CountUserQueryResult
                    {
                        Day = 1,
                        Month = 1,
                        Year = i.Key,
                        Count = i.Count()
                    })
                   .OrderBy(x => x.Year),
                cancellation: cancellationToken),

                _ => throw new ArgumentOutOfRangeException(nameof(request.CountBy), "Invalid CountBy value"),
            };
           
            if (!result.Any())
                throw new NotFoundException("Not found");
            return result.MapToPagedResult(x => x);
        }
    }
} 
