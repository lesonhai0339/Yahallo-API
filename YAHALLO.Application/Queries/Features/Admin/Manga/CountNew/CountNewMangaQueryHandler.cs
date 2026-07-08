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

namespace YAHALLO.Application.Queries.Features.Admin.Manga.CountNew
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
            var from = request.From.Date.AddMinutes(-request.TimeZoneOffset);
            var toExclusive = request.To.Date.AddDays(1).AddMinutes(-request.TimeZoneOffset);

            var query = _mangaRepository.CreateQueryable();
            query = query.Where(u => u.CreateDate >= from && u.CreateDate <= toExclusive);


            var result = request.CountBy switch
            {
                MangaCountBy.Day => await _mangaRepository.FindAllSelectAsync(
                    pageNo: request.PageNo,
                    pageSize: request.PageSize,
                    selector: _ => query
                        .GroupBy(x => x.CreateDate.AddMinutes(request.TimeZoneOffset).Date)
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
                   selector: _ => query
                       .GroupBy(x => new { x.CreateDate.AddMinutes(request.TimeZoneOffset).Month, x.CreateDate.AddMinutes(request.TimeZoneOffset).Year})
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
                   selector: _ => query
                       .GroupBy(x => x.CreateDate.AddMinutes(request.TimeZoneOffset).Year)
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
