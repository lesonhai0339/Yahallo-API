using AutoMapper;
using LinqKit;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.MangaQuery.FilterManga;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.MangaRating;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterMangaRatingQueryHandler : IRequestHandler<FilterMangaRatingQuery, PagedResult<MangaRatingDto>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        public FilterMangaRatingQueryHandler(IMangaRatingRepository mangaRatingRepository)
        {
            _mangaRatingRepository = mangaRatingRepository;
        }

        public async Task<PagedResult<MangaRatingDto>> Handle(FilterMangaRatingQuery request, CancellationToken cancellationToken)
        {
            var query = _mangaRatingRepository.CreateQueryable();

            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listMangaRating = await _mangaRatingRepository
                .FindAllSelectAsync(
                request.PageNumber,
                request.PageSize,
                _ => query
                    .Select(t => new MangaRatingDto
                    {
                        Id = t.Id,   
                        MangaId = t.MangaId,
                        MangaName = t.Manga.Name,
                        Userid = t.UserId,
                        UserName = t.User.DisplayName,
                        Rating = t.Rating
                    }),
                cancellationToken);
            if(!listMangaRating.Any())
                throw new NotFoundException("Không tìm thấy bất kỳ MangaRating nào phù hợp");

            return listMangaRating.MapToPagedResult(x => x);
        }
        private IQueryable<MangaRatingEntity> ApplySorting(IQueryable<MangaRatingEntity> filter, FilterMangaRatingQuery request)
        {
            return request.SortBy switch
            {
                MangaRatingSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.Rating, request.ReverserSort),
                _=> filter.OrderBy(x => x.Id), 
            };
        }
        private IQueryable<MangaRatingEntity> ApplyFilter(IQueryable<MangaRatingEntity> query, FilterMangaRatingQuery request)
        {
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId == request.UserId);

            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.Manga.Name.Contains(request.MangaName));

            if (!string.IsNullOrEmpty(request.UserName)) query = query.Where(x => !string.IsNullOrEmpty(x.User.DisplayName) && x.User.DisplayName!.Contains(request.UserName));

            return query;
        }
    }
}
