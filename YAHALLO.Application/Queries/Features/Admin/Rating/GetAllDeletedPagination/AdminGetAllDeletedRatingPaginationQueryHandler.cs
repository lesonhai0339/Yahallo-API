using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Manga;
using YAHALLO.Application.Queries.Features.Admin.User;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Rating.GetAllDeletedPagination
{
    public sealed class AdminGetAllDeletedRatingPaginationQueryHandler : IRequestHandler<AdminGetAllDeletedRatingPaginationQuery, PagedResult<AdminRatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public AdminGetAllDeletedRatingPaginationQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<AdminRatingDto>> Handle(AdminGetAllDeletedRatingPaginationQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository
                .FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: x => x
                    .Where(r => !string.IsNullOrEmpty(r.IdUserDelete) && r.DeleteDate.HasValue)
                    .Select(t => new AdminRatingDto
                    {

                        Id = t.Id,
                        UserId = t.UserId,
                        UserName = t.User!.DisplayName,
                        Rating = t.Rating,
                        Manga = t.ToManga == null ? null : new AdminMangaDto
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
                        Chapter = t.ToChapter == null ? null : new AdminChapterDto
                        {
                            Id = t.ToChapter.Id,
                            MangaId = t.ToChapter.MangaId!,
                            Index = t.ToChapter.Index,
                            Title = t.ToChapter.Title,
                            CreateDate = t.ToChapter.CreateDate,
                        },
                        User = t.ToUser == null ? null : new AdminUserDto
                        {
                            Id = t.ToUser.Id,
                            DisplayName = t.ToUser.DisplayName,
                            Avatar = t.ToUser.AvatarThumbnail,
                        }
                    }),
                    cancellation: cancellationToken,
                    ignoreQueryFilters: true);

            return ratings.MapToPagedResult(x => x);
        }
    }
}
