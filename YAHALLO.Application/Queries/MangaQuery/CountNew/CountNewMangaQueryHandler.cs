using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.CountNew
{
    public class CountNewMangaQueryHandler : IRequestHandler<CountNewMangaQuery, PagedResult<CountNewMangaQueryResult>>
    {
        private readonly IMangaRepository _mangaRepository; 
        public CountNewMangaQueryHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }   
        public async Task<PagedResult<CountNewMangaQueryResult>> Handle(CountNewMangaQuery request, CancellationToken cancellationToken)
        {
            var result = request.CountBy switch
            {
                MangaCountBy.Day => await _mangaRepository.FindAllSelectAsync(
                    pageNo: request.PageNo,
                    pageSize: request.PageSize,
                    selector: x=> x
                        .Where(m => m.CreateDate >= request.From && m.CreateDate <= request.To)
                        .GroupBy(x => x.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Date)
                        .Select(i => new CountNewMangaQueryResult
                        {
                            Day = i.Key.Day,
                            Month = i.Key.Month,
                            Year = i.Key.Year,
                            Count = i.Count()
                        })
                        .OrderBy(x => x.Year).ThenBy(x => x.Month).ThenBy(x => x.Day),
                    cancellation: cancellationToken
                    ),

                MangaCountBy.Month => await _mangaRepository.FindAllSelectAsync(
                   pageNo: request.PageNo,
                   pageSize: request.PageSize,
                   selector: x => x
                        .Where(m => m.CreateDate >= request.From && m.CreateDate <= request.To)
                       .GroupBy(x => new { Month = x.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Month, Year = x.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Year})
                       .Select(i => new CountNewMangaQueryResult
                       {
                           Day = 1,
                           Month = i.Key.Month,
                           Year = i.Key.Year,
                           Count = i.Count()    
                       })
                       .OrderBy(x => x.Year).ThenBy(x => x.Month),
                   cancellation: cancellationToken
                   ),

                MangaCountBy.Year => await _mangaRepository.FindAllSelectAsync(
                   pageNo: request.PageNo,
                   pageSize: request.PageSize,
                   selector: x => x
                        .Where(m => m.CreateDate >= request.From && m.CreateDate <= request.To)
                       .GroupBy(x => x.CreateDate!.Value.AddMinutes(request.TimeZoneOffset).Year)
                       .Select(i => new CountNewMangaQueryResult
                       {
                           Day = 1,
                           Month = 1,
                           Year = i.Key,
                           Count = i.Count()
                       })
                       .OrderBy(x => x.Year),
                   cancellation: cancellationToken
                   ),

                _ => throw new ArgumentOutOfRangeException(nameof(request.CountBy), "Invalid CountBy value") 
            };
            return result.MapToPagedResult(x => x);
        }
    }
}
