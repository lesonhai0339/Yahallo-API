using AutoMapper;
using LinqKit;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.UserQuery.DTOs;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser
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
            var query = _userRepository.CreateQueryable();

            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listUsers = await _userRepository.FindAllSelectAsync(
                pageNo: request.PageNumber,
                pageSize: request.PageSize,
                selector: _ => query
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
