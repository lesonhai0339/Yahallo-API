using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.RoleQuery.GetAllDeleted
{
    public class GetAllRoleDeletedQueryHandler : IRequestHandler<GetAllRoleDeletedQuery, List<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetAllRoleDeletedQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetAllRoleDeletedQuery request, CancellationToken cancellationToken)
        {
            var listRoleExists = await _roleRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (!listRoleExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ role nào");
            }
            return listRoleExists.MapToRoleDtoToList(_mapper);
        }
    }
}
