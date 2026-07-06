using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Follow;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.FollowQuery.Filter
{
    public class FilterFollowMangaQueryHandler : IRequestHandler<FilterFollowMangaQuery, PagedResult<FollowMangaDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly ICurrentUserService _currentUser;
        public FilterFollowMangaQueryHandler(IFollowRepository followRepository, ICurrentUserService currentUser)
        {
            _followRepository = followRepository;
            _currentUser = currentUser; 
        }

        public async Task<PagedResult<FollowMangaDto>> Handle(FilterFollowMangaQuery request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            request.UserId = (isStaff && !string.IsNullOrEmpty(request.UserId))
                ? request.UserId 
                : _currentUser.UserId;

            var query = _followRepository.CreateQueryable();
            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listFollowMangaExists = await _followRepository
                .FindAllSelectAsync(
                pageNo: request.PageNumber,
                pageSize: request.PageSize,
                selector: _=>
                    query.Select(x => new FollowMangaDto
                    {
                        MangaId = x.MangaId,
                        UserId = x.UserId,
                        MangaName = x.Manga.Name,
                        UserName = x.User.DisplayName,
                        Avatar = x.Manga.MangaThumbnail,
                        Background = x.Manga.MangaBackground,
                        LastUpdate = x.Manga.LastChapterUpdate
                    }),
                cancellation: cancellationToken);
            if(!listFollowMangaExists.Any())
                throw new NotFoundException("Không tìm thấy bất kỳ bản ghi nào phù hợp yêu cầu");

            return listFollowMangaExists.MapToPagedResult(x => x);
        }
        public IQueryable<FollowEntity> ApplyFilter(IQueryable<FollowEntity> query, FilterFollowMangaQuery request)
        {
            if (!string.IsNullOrEmpty(request.UserId)) query = query.Where(x => x.UserId == request.UserId);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.UserName)) query = query.Where(x => x.User.DisplayName!.Contains(request.UserName));
            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.Manga.Name!.Contains(request.MangaName));

            return query;
        }
        public IQueryable<FollowEntity> ApplySorting(IQueryable<FollowEntity> query, FilterFollowMangaQuery request)
        {
            return request.SortBy switch
            {
                FollowSortBy.LastUpdate => OrderHelper.ApplyOrder(query, x => x.CreateDate, request.ReverseSort),
                _ => query
            };
        }
    }
}
