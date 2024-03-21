using AutoMapper;
using LinqKit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.FilterUser
{
    public class FilterUserQueryHandler : IRequestHandler<FilterUserQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterUserQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IFilters filters)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _filters = filters;
        }
        public async Task<PagedResult<UserDto>> Handle(FilterUserQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<UserEntity>, IQueryable<UserEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                if (!string.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(x => x.Email == request.Email);
                }
                if (!string.IsNullOrEmpty(request.Phone))
                {
                    query = query.Where(x => x.PhoneNumber == request.Phone);
                }
                return query;
            };
            var listUsers = await _userRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!listUsers.Any())
            {
                throw new NotFoundException("Không tìm thấy thành viên nào theo yêu cầu");
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                var filterName = listUsers
                    .Where(x => _filters.CheckString(x.DisplayName, request.Name) || _filters.CheckString(x.FirstName + x.LastName, request.Name)).ToList();
                var mapping = filterName.MapToUserDtoToList(_mapper);
                return PagedResult<UserDto>.Create(
                    totalCount: filterName.Count,
                    pageCount: filterName.Count / request.PageSize + (filterName.Count % request.PageSize == 0 ? 0 : 1),
                    pageSize: request.PageSize,
                    pageNumber: request.PageNumber,
                    data: mapping);
            }
            return listUsers.MapToPagedResult(x => x.MapToUserDto(_mapper));
        }
    }
}
