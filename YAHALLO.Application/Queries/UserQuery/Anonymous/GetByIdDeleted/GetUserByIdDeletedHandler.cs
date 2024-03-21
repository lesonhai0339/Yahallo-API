using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetByIdDeleted
{
    public class GetUserByIdDeletedHandler : IRequestHandler<GetUserByIdDeleted, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdDeletedHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdDeleted request, CancellationToken cancellationToken)
        {
            var checkUser = await _userRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (checkUser == null)
            {
                throw new NotFoundException($"Không tìm thấy thành viên với Id {request.Id}");
            }
            return checkUser.MapToUserDto(_mapper);
        }
    }
}
