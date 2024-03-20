using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.GetAllDeletedPagination
{
    public class GetAllUserDeletedPaginationQueryHandler : IRequestHandler<GetAllUserDeletedPaginationQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserDeletedPaginationQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<UserDto>> Handle(GetAllUserDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var listUsers = await _userRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (!listUsers.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ thành viên nào");
            }
            return listUsers.MapToPagedResult(x => x.MapToUserDto(_mapper));
        }
    }
}
