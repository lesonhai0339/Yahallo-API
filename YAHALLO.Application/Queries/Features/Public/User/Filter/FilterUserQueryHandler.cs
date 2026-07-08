using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.User.Filter
{
    public class FilterUserQueryHandler : IRequestHandler<FilterUserQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public FilterUserQueryHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PagedResult<UserDto>> Handle(FilterUserQuery request, CancellationToken cancellationToken)
        {
            var listUsers = await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNo,
                pageSize: request.PageSize,
                selector: q =>
                ApplySorting(ApplyFilter(q, request), request)
                    .Select(u => new UserDto
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
        private IQueryable<UserEntity> ApplySorting(IQueryable<UserEntity> query, FilterUserQuery request)
        {
            return request.SortBy switch
            {
                UserSortBy.Level => OrderHelper.ApplyOrder(query, x => x.Level, request.ReverseSort),
                _ => query
            };
        }
        private IQueryable<UserEntity> ApplyFilter(IQueryable<UserEntity> query, FilterUserQuery request)
        {
            if (!string.IsNullOrEmpty(request.Email)) query = query.Where(x => x.Email == request.Email);

            if (!string.IsNullOrEmpty(request.Phone)) query = query.Where(x => x.PhoneNumber == request.Phone);

            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.DisplayName!.Contains(request.Name));
            return query;   
        }
       
    }
}
