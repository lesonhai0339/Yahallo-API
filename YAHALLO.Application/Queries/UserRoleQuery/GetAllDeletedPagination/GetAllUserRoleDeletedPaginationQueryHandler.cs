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

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAllDeletedPagination
{
    public class GetAllUserRoleDeletedPaginationQueryHandler : IRequestHandler<GetAllUserRoleDeletedPaginationQuery, PagedResult<UserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public GetAllUserRoleDeletedPaginationQueryHandler(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<UserRoleDto>> Handle(GetAllUserRoleDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var listUserRoleExists = await _userRoleRepository
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if (listUserRoleExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ UserRole nào");
            }
            return listUserRoleExists.MapToPagedResult(x => x.MapToUserRoleDto(_mapper));
        }
    }
}
