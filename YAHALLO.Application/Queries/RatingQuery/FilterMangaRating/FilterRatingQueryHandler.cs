using MediatR;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.ChapterQuery;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Application.Queries.UserQuery;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.MangaRating;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterRatingQueryHandler : IRequestHandler<FilterRatingQuery, PagedResult<RatingDto>>
    {
        private readonly ICurrentUserService _currentUserService;   
        private readonly IRatingRepository _mangaRatingRepository;
        public FilterRatingQueryHandler(IRatingRepository ratingRepository, ICurrentUserService currentUser)
        {
            _mangaRatingRepository = ratingRepository;
            _currentUserService = currentUser;  
        }

        public async Task<PagedResult<RatingDto>> Handle(FilterRatingQuery request, CancellationToken cancellationToken)
        {
            var query = _mangaRatingRepository.CreateQueryable();

            query = await ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listMangaRating = await _mangaRatingRepository
                .FindAllSelectAsync(
                request.PageNumber,
                request.PageSize,
                _ => query
                    .Select(t => new RatingDto
                    {
                        Id = t.Id,   
                        UserId = t.UserId,
                        UserName = t.User!.DisplayName,
                        Rating = t.Rating,
                        Manga = t.ToManga == null ? null : new MangaDto
                        {
                            Id = t.ToManga.Id,
                            DisplayName = t.ToManga.Name,
                            MangaThumbnail = t.ToManga.MangaThumbnail,
                            MangaBackground = t.ToManga.MangaBackground,
                            Countries = (CountriesEnum)t.ToManga.Countries,
                            Description = t.ToManga.Description,    
                            Status = (MangaStatus)t.ToManga.Status,
                            Season = t.ToManga.Season,
                        },
                        Chapter = t.ToChapter == null ? null : new ChapterDto
                        {
                            Id = t.ToChapter.Id,
                            MangaId = t.ToChapter.MangaId!,
                            Index = t.ToChapter.Index,
                            Title = t.ToChapter.Title,
                            CreateDate = t.ToChapter.CreateDate,
                        },
                        User = t.ToUser == null ? null : new UserDto
                        {
                            Id = t.ToUser.Id,
                            DisplayName = t.ToUser.DisplayName, 
                            Avatar = t.ToUser.AvatarThumbnail,  
                        }
                    }),
                cancellationToken);
            if(!listMangaRating.Any())
                throw new NotFoundException("Không tìm thấy bất kỳ MangaRating nào phù hợp");

            return listMangaRating.MapToPagedResult(x => x);
        }
        private IQueryable<RatingEntity> ApplySorting(IQueryable<RatingEntity> filter, FilterRatingQuery request)
        {
            return request.SortBy switch
            {
                MangaRatingSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.Rating, request.ReverserSort),
                _=> filter.OrderBy(x => x.Id), 
            };
        }
        private async Task<IQueryable<RatingEntity>> ApplyFilter(IQueryable<RatingEntity> query, FilterRatingQuery request)
        {
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.ToMangaId == request.MangaId);


            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.ToManga != null && x.ToManga.Name.Contains(request.MangaName));

            if (!string.IsNullOrEmpty(request.UserName)) query = query.Where(x => x.User != null && x.User.DisplayName != null && x.User.DisplayName!.Contains(request.UserName));

            if (!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ToChapterId == request.ChapterId);

            if (!string.IsNullOrEmpty(request.ToUserId)) query = query.Where(x => x.ToUserId == request.ToUserId);

            var isStaff = await _currentUserService.AuthorizeAsync(Policies.ModOrAdmin);
            var targetId = (isStaff && !string.IsNullOrEmpty(request.UserId))
                ? request.UserId
                : _currentUserService.UserId;

            if (!string.IsNullOrEmpty(targetId)) query = query.Where(x => x.UserId == targetId);
            return query;
        }
    }
}
