using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (!users.Any())
            {
                throw new NotFoundException("Không tìm thấy thành viên nào");
            }
            return users.MapToUserDtoToList(_mapper);
        }
    }
}
