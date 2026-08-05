using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Admin.Comment.Filter;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Comment;
using YAHALLO.Domain.Enums.Follow;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.Filter
{
    public class AdminFilterFollowQueryHandler : IRequestHandler<AdminFilterFollowQuery, PagedResult<AdminFollowDto>>
    {
        private readonly IFollowRepository _followrepository;
        public AdminFilterFollowQueryHandler(IFollowRepository followrepository)
        {
            _followrepository = followrepository;
        }
        public async Task<PagedResult<AdminFollowDto>> Handle(AdminFilterFollowQuery request, CancellationToken cancellationToken)
        {
            var follows = await _followrepository.FindAllSelectAsync(
               pageNo: request.PageNo,
               pageSize: request.PageSize,
               selector: q =>
               ApplySorting(ApplyFilter(q, request), request)
                   .Select(t => new AdminFollowDto
                   {
                       MangaId = t.MangaId,
                       UserId = t.UserId,
                       UserName = t.User.DisplayName,
                       UserAvatar = t.User.AvatarThumbnail,     
                       MangaThumbnail = t.Manga.MangaThumbnail,
                       MangaBackground = t.Manga.MangaBackground,
                       MangaName = t.Manga.Name,
                       CreateDate = t.CreateDate,
                       UpdateDate = t.UpdateDate,
                       DeleteDate = t.DeleteDate,   
                   }),
               cancellation: cancellationToken,
               ignoreQueryFilters: request.IsDeleted);

            return follows.MapToPagedResult(x => x);
        }
        private IQueryable<FollowEntity> ApplyFilter(IQueryable<FollowEntity> query, AdminFilterFollowQuery request)
        {
            return request.SortBy switch
            {
                FollowSortBy.LastUpdate => OrderHelper.ApplyOrder(query, x => x.UpdateDate, request.ReverseSort),
                _ => query
            };
        }
        private IQueryable<FollowEntity> ApplySorting(IQueryable<FollowEntity> query, AdminFilterFollowQuery request)
        {
            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId == request.UserId);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            if (request.From != null && request.To != null)
            {
                var from = request.From.Value.UtcDateTime;
                var to = request.To.Value.AddDays(1).UtcDateTime;
                query = query.Where(x => x.CreateDate >= from && x.CreateDate <= to);
            }

            if (request.IsDeleted)
                query = query.Where(x => x.DeleteDate.HasValue);

            return query;
        }
    }
}
