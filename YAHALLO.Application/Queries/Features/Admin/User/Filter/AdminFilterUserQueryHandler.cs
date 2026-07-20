using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.User.Filter
{
    public sealed class AdminFilterUserQueryHandler : IRequestHandler<AdminFilterUserQuery, PagedResult<AdminUserDto>>
    {
        private readonly IUserRepository _userRepository;

        public AdminFilterUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PagedResult<AdminUserDto>> Handle(AdminFilterUserQuery request, CancellationToken cancellationToken)
        {
            var query = _userRepository.CreateQueryable();

            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listUsers = await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: _ => query
                    .Select(u => new AdminUserDto
                    {
                        Id = u.Id,
                        Avatar = u.AvatarThumbnail,
                        Background = u.BackgroundThumbnail,
                        DisplayName = u.DisplayName,
                        Email = u.Email,
                        Level = u.Level,
                        PhoneNumber = u.PhoneNumber,
                        Status = u.Status,
                    }),
                cancellation: cancellationToken);

            return listUsers.MapToPagedResult(x => x);
        }
        private IQueryable<UserEntity> ApplySorting(IQueryable<UserEntity> query, AdminFilterUserQuery request)
        {
            return request.SortBy switch
            {
                UserSortBy.Level => OrderHelper.ApplyOrder(query, x => x.Level, request.ReverseSort),
                _ => query
            };
        }
        private IQueryable<UserEntity> ApplyFilter(IQueryable<UserEntity> query, AdminFilterUserQuery request)
        {
            if (!string.IsNullOrEmpty(request.Email)) query = query.Where(x => x.Email == request.Email);

            if (!string.IsNullOrEmpty(request.Phone)) query = query.Where(x => x.PhoneNumber == request.Phone);

            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.DisplayName!.Contains(request.Name));

            if(request.CreateDate != null)
            {
                var date = request.CreateDate?.UtcDateTime;           
                var nextDay = date?.AddDays(1);
                query = query.Where(x => x.CreateDate >= date && x.CreateDate < nextDay);
            }
            return query;
        }
    }
}
