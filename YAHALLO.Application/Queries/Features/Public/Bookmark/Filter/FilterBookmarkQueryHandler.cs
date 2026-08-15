//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.BookmarkEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Bookmark.Filter
{
    public class FilterBookmarkQueryHandler : IRequestHandler<FilterBookmarkQuery, PagedResult<BookmarkDto>>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICurrentUserService _currentUser;
        public FilterBookmarkQueryHandler(IBookmarkRepository bookmarkRepository, ICurrentUserService currentUser)
        {
            _bookmarkRepository = bookmarkRepository;
            _currentUser = currentUser;
        }

        public async Task<PagedResult<BookmarkDto>> Handle(FilterBookmarkQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để xem dấu trang");

            // Dấu trang là dữ liệu riêng tư: người thường luôn chỉ thấy của mình,
            // bất kể truyền UserId nào lên.
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            var targetUserId = (isStaff && !string.IsNullOrEmpty(request.UserId))
                ? request.UserId
                : userId;

            var bookmarks = await _bookmarkRepository.FindAllSelectAsync(
                request.PageNo,
                request.PageSize,
                selector: q =>
                    ApplySorting(ApplyFilter(q, request, targetUserId), request)
                        .Select(x => new BookmarkDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Descriptions = x.Descriptions,
                            UserId = x.UserId,
                            MangaId = x.MangaId,
                            MangaName = x.Manga == null ? null : x.Manga.Name,
                            MangaThumbnail = x.Manga == null ? null : x.Manga.MangaThumbnail,
                            ChapterId = x.ChapterId,
                            ChapterIndex = x.Chapter == null ? null : x.Chapter.Index,
                            ChapterSubIndex = x.Chapter == null ? null : x.Chapter.SubIndex,
                            BlogId = x.BlogId,
                            BlogTitle = x.Blog == null ? null : x.Blog.Title,
                            CreateDate = x.CreateDate,
                        }),
                cancellationToken);

            return bookmarks.MapToPagedResult(x => x);
        }

        private IQueryable<BookmarkEntity> ApplySorting(IQueryable<BookmarkEntity> filter, FilterBookmarkQuery request)
        {
            return request.SortBy switch
            {
                BookmarkSortBy.Name => OrderHelper.ApplyOrder(filter, x => x.Name, request.ReverseSort),
                _ => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
            };
        }

        private IQueryable<BookmarkEntity> ApplyFilter(
            IQueryable<BookmarkEntity> query, FilterBookmarkQuery request, string targetUserId)
        {
            query = query.Where(x => x.UserId == targetUserId);

            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.Name.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            if (!string.IsNullOrEmpty(request.ChapterId)) query = query.Where(x => x.ChapterId == request.ChapterId);

            if (!string.IsNullOrEmpty(request.BlogId)) query = query.Where(x => x.BlogId == request.BlogId);

            return query;
        }
    }
}
