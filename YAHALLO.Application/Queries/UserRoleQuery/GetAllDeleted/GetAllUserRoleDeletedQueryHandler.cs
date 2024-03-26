using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserRoleQuery.GetAllDeleted
{
    public class GetAllUserRoleDeletedQueryHandler : IRequestHandler<GetAllUserRoleDeletedQuery, List<UserRoleDto>>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public GetAllUserRoleDeletedQueryHandler(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }
        public async Task<List<UserRoleDto>> Handle(GetAllUserRoleDeletedQuery request, CancellationToken cancellationToken)
        {
            var listUserRoleExists = await _userRoleRepository
               .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (listUserRoleExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ UserRole nào");
            }
            return listUserRoleExists.MapToUserRoleDtoToList(_mapper);
        }
    }
}
