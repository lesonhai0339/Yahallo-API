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
            var query = _userRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email == request.Email);
            }
            if (!string.IsNullOrEmpty(request.Phone))
            {
                query = query.Where(x => x.PhoneNumber == request.Phone);
            }
            if( !string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                var filters = _filters.CheckString(request.Name);
                var predicate = PredicateBuilder.New<UserEntity>();
                foreach(var filter in filters) 
                {
                    predicate = predicate
                        .Or(x => x.DisplayName != null ? x.DisplayName.Contains(filter) : (x.FirstName + x.LastName).Contains(filter));
                }
                query = query.Where(predicate);
            }
            var listUsers = await _userRepository.FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if (!listUsers.Any())
            {
                throw new NotFoundException("Không tìm thấy thành viên nào theo yêu cầu");
            }
            return listUsers.MapToPagedResult(x => x.MapToUserDto(_mapper));
        }
    }
}
