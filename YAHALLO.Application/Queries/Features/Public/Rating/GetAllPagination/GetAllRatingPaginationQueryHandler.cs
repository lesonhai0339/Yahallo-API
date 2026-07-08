using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Rating.GetAllPagination
{
    public class GetAllRatingPaginationQueryHandler : IRequestHandler<GetAllRatingPaginationQuery, PagedResult<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        public GetAllRatingPaginationQueryHandler(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<PagedResult<RatingDto>> Handle(GetAllRatingPaginationQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository
                .FindAllSelectAsync(
                request.PageNo,
                request.PageSize,
                selector: q => q
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

            return ratings.MapToPagedResult(x => x);
        }
    }
}
