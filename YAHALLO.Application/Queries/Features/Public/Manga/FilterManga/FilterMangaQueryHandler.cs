using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Manga.FilterManga
{
    public class FilterMangaQueryHandler : IRequestHandler<FilterMangaQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        public FilterMangaQueryHandler(
            IMangaRepository mangaRepository
            )
        {
            _mangaRepository = mangaRepository;
        }

        public async Task<PagedResult<MangaDto>> Handle(FilterMangaQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(m => new MangaDto
                    {
                        Id = m.Id,
                        DisplayName = (m.Name + " " + m.SeasonName).Trim(),
                        Description = m.Description,
                        Level = m.Level,
                        Status = m.Status,
                        Type = m.Type,
                        Countries = m.Countries,
                        Season = m.Season,
                        MangaThumbnail = m.MangaThumbnail,
                        MangaBackground = m.MangaBackground,
                        UserId = m.UserId,
                        ViewCount = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                        Rating = m.RatingEntities.Select(x => (int?)x.Rating).Average(),
                        LastestChapter = m.LastChapter == null ? null : new ChapterDto
                        {
                            Id = m.LastChapter.Id,
                            Index = m.LastChapter.Index,
                            CreateDate = m.LastChapter.CreateDate,
                            Title = m.LastChapter.Title,
                            MangaId = m.Id,
                            MangaName = m.Name
                        },
                        Tags = m.TagEntities.Select(t => new TagDto
                        {
                            Id = t.TagId,
                            Name = t.Tag.Name,
                            Description = t.Tag.Description
                        }).ToList()
                    }),
                cancellation: cancellationToken);

            return mangas.MapToPagedResult(x => x);
        }
        private IQueryable<MangaEntity> ApplySorting(IQueryable<MangaEntity> filter, FilterMangaQuery request)
        {
            return request.SortBy switch
            {
                MangaSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.LastChapterUpdate, request.ReverseSort),
                MangaSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities.Average(x => (double?)x.Rating) ?? 0, request.ReverseSort),
                MangaSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.TotalCount, request.ReverseSort),
                MangaSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities.Count, request.ReverseSort),
                MangaSortBy.ChapterCount => OrderHelper.ApplyOrder(filter, x => x.ChaptersEntities.Count, request.ReverseSort),
                _=> filter.OrderBy(x => x.Id)
            };
        }
        private IQueryable<MangaEntity> ApplyFilter(IQueryable<MangaEntity> query, FilterMangaQuery request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                var name = request.Name.Trim();
                query = query.Where(x =>
                    x.Name.Trim().Contains(name)
                    || x.SeasonName.Trim().Contains(name)
                    || x.AuthorEntities.Any(a => a.Author.Name.Contains(name))
                    || x.ArtistEntities.Any(a => a.Artist.Name.Contains(name))
                    || x.TagEntities.Any(t => t.Tag.Name.Contains(name)));
            }
            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.Name.Trim().Contains(request.Name.Trim()));
            if (request.Level != null) query = query.Where(x => x.Level == request.Level);
            if (request.Status != null)  query = query.Where(x => x.Status == request.Status);
            if (request.Type != null)query = query.Where(x => x.Type == request.Type);
            if (request.Countries != null) query = query.Where(x => x.Countries == request.Countries);
            if (request.DateUpdate != null) query = query.Where(x => x.UpdateDate == request.DateUpdate);
            if (request.UserId != null) query = query.Where(x => x.UserId == request.UserId);
            if(request.Season > 0)
            {
                var startYear = new DateTime(request.Season, 1, 1);
                var endYear = new DateTime(request.Season + 1, 1, 1);
                query = query.Where(x => x.CreateDate >= startYear && x.CreateDate < endYear);
            }
            if (!string.IsNullOrEmpty(request.AuthorId)) query = query.Where(x => x.AuthorEntities.Any(a => a.AuthorId == request.AuthorId));
            if (!string.IsNullOrEmpty(request.ArtistId))query = query.Where(x => x.ArtistEntities.Any(a => a.ArtistId == request.ArtistId));
            if (!string.IsNullOrEmpty(request.TagIds))
            {
                var tags = request.TagIds.Split(',').Select(x => x.Trim()).ToList();
                query = query.Where(x => tags.All(tagId => x.TagEntities!.Any(t => t.TagId.Trim() == tagId)));
            }
            return query;
        }
    }
}
