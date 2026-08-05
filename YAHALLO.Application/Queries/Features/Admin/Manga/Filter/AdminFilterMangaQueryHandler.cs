using MediatR;
using System;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Artist;
using YAHALLO.Application.Queries.Features.Admin.Author;
using YAHALLO.Application.Queries.Features.Admin.Chapter;
using YAHALLO.Application.Queries.Features.Admin.Tag;
using YAHALLO.Application.Queries.Features.Public.Artist;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.Filter
{
    public sealed class AdminFilterMangaQueryHandler : IRequestHandler<AdminFilterMangaQuery, PagedResult<AdminMangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        public AdminFilterMangaQueryHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public async Task<PagedResult<AdminMangaDto>> Handle(AdminFilterMangaQuery request, CancellationToken cancellationToken)
        {
            var mangas = await _mangaRepository.FindAllSelectAsync(
               pageNo: request.PageNo,
               pageSize: request.PageSize,
               selector: q =>
               ApplySorting(ApplyFilter(q, request), request)
                   .Select(m => new AdminMangaDto
                   {
                       Id = m.Id,
                       DisplayName = m.Name.Trim(),
                       Description = m.Description,
                       Level = m.Level,
                       Status = m.Status,
                       Mode = m.DisplayMode,
                       Type = m.Type,
                       Countries = m.Countries,
                       Season = m.Season,
                       MangaThumbnail = m.MangaThumbnail,
                       MangaBackground = m.MangaBackground,

                       TotalChapter = m.ChaptersEntities.Count(),
                       TotalComment = m.CommentEntities.Count(),
                       TotalView = m.ViewCount == null ? 0 : m.ViewCount.TotalCount,
                       Rating = m.RatingEntities.Select(x => (int?)x.Rating).Average(),
                       CreateDate = m.CreateDate,
                       UpdateDate = m.UpdateDate,
                       DeleteDate = m.DeleteDate,   
                       Owner = new Owner
                       {
                           Id = m.UserEntity.Id,
                           Name = m.UserEntity.DisplayName
                       },
                       Authors = m.AuthorEntities
                        .Select(a => new AdminAuthorDto
                        {
                            Id = a.AuthorId,
                            Name = a.Author.Name,
                            Birth = a.Author.Birth,
                            Country = a.Author.Countries.ToString(),
                            Depscription = a.Author.Depscription,
                            LifeStatus = a.Author.LifeStatus.ToString(),
                        }).ToList(),
                        Artists = m.ArtistEntities
                        .Select(a => new AdminArtistDto
                        {
                            Id = a.ArtistId,
                            Name = a.Artist.Name,
                            Birth = a.Artist.Birth,
                            Country = a.Artist.Countries.ToString(),
                            Depscription = a.Artist.Depscription,
                            LifeStatus = a.Artist.LifeStatus.ToString(),
                        }).ToList(),
                       Tags = m.TagEntities.Select(t => new AdminTagDto
                       {
                           Id = t.TagId,
                           Name = t.Tag.Name,
                           Description = t.Tag.Description
                       }).ToList()
                   }),
                cancellation: cancellationToken,
               ignoreQueryFilters: request.IsDeleted);

            return mangas.MapToPagedResult(x => x);
        }
        private IQueryable<MangaEntity> ApplySorting(IQueryable<MangaEntity> filter, AdminFilterMangaQuery request)
        {
            var q =  request.SortBy switch
            {
                MangaSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.UpdateDate, request.ReverseSort),
                MangaSortBy.CreateDate => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
                MangaSortBy.Deletedate => OrderHelper.ApplyOrder(filter, x => x.DeleteDate, request.ReverseSort),
                MangaSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities.Average(x => (double?)x.Rating) ?? 0, request.ReverseSort),
                MangaSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.TotalCount, request.ReverseSort),
                MangaSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities.Count, request.ReverseSort),
                MangaSortBy.ChapterCount => OrderHelper.ApplyOrder(filter, x => x.ChaptersEntities.Count, request.ReverseSort),
                _ => OrderHelper.ApplyOrder(filter, x => x.Id, request.ReverseSort)
            };
            return q.ThenBy(x => x.Id);
        }
        private IQueryable<MangaEntity> ApplyFilter(IQueryable<MangaEntity> query, AdminFilterMangaQuery request)
        {

            if(!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.Id == request.MangaId);   

            if (!string.IsNullOrEmpty(request.Name))
            {
                var name = request.Name.Trim();
                query = query.Where(x =>
                    x.Name.Contains(name)
                    || x.AuthorEntities.Any(a => a.Author.Name.Contains(name))
                    || x.ArtistEntities.Any(a => a.Artist.Name.Contains(name))
                    || x.TagEntities.Any(t => t.Tag.Name.Contains(name)));
            }
            if (request.Level != null) query = query.Where(x => x.Level == request.Level);
            if (request.Status != null) query = query.Where(x => x.Status == request.Status);
            if (request.DisplayMode != null) query = query.Where(x => x.DisplayMode == request.DisplayMode);
            if (request.Type != null) query = query.Where(x => x.Type == request.Type);
            if (request.Countries != null) query = query.Where(x => x.Countries == request.Countries);
            if (request.Date != null)
            {
                var from = request.Date?.UtcDateTime;
                var to = request.Date?.AddDays(1).UtcDateTime;

                query = query.Where(x => x.CreateDate >= from && x.CreateDate < to);
            }
            if (request.UserId != null) query = query.Where(x => x.UserId == request.UserId);
            if (request.Season > 0)
            {
                var startYear = new DateTime(request.Season, 1, 1);
                var endYear = new DateTime(request.Season + 1, 1, 1);
                query = query.Where(x => x.CreateDate >= startYear && x.CreateDate < endYear);
            }
            if (!string.IsNullOrEmpty(request.AuthorId)) query = query.Where(x => x.AuthorEntities.Any(a => a.AuthorId == request.AuthorId));
            if (!string.IsNullOrEmpty(request.ArtistId)) query = query.Where(x => x.ArtistEntities.Any(a => a.ArtistId == request.ArtistId));
            if (!string.IsNullOrEmpty(request.TagIds))
            {
                var tags = request.TagIds.Split(',').Select(x => x.Trim()).ToList();
                query = query.Where(x => tags.All(tagId => x.TagEntities!.Any(t => t.TagId.Trim() == tagId)));
            }

            if (request.IsDeleted)
                query = query.Where(x => x.DeleteDate.HasValue);

            return query;
        }
    }
}
