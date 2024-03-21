using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetById
{
    public class GetUserByIdQueryhandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryhandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var checkUserExists = await _userRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkUserExists == null)
            {
                throw new NotFoundException($"Không tìm thấy Thành viên với Id {request.Id}");
            }
            return checkUserExists.MapToUserDto(_mapper);
        }
    }
}
