using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllDeletedPagination
{
    public class GetAllRoleDeletedPaginationQueryHandler : IRequestHandler<GetAllRoleDeletedPaginationQuery, PagedResult<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetAllRoleDeletedPaginationQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<RoleDto>> Handle(GetAllRoleDeletedPaginationQuery request, CancellationToken cancellationToken)
        {
            var listRoleExists = await _roleRepository
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue,
                             request.PageNumber, request.PageSize, cancellationToken);
            if (!listRoleExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ role nào");
            }
            return listRoleExists.MapToPagedResult(x => x.MapToRoleDto(_mapper));
        }
    }
}
