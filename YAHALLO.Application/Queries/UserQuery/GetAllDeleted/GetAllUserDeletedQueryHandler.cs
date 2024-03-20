using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.GetAllDeleted
{
    public class GetAllUserDeletedQueryHandler : IRequestHandler<GetAllUserDeletedQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserDeletedQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUserDeletedQuery request, CancellationToken cancellationToken)
        {
            var listUsers = await _userRepository.FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (listUsers == null)
            {
                throw new NotFoundException("Không tìm thấy thành viên nào");
            }
            return listUsers.MapToUserDtoToList(_mapper);
        }
    }
}
