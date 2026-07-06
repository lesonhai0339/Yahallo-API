using AutoMapper;
using MediatR;
using YAHALLO.Application.Queries.UserQuery.DTOs;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserQuery.GetByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public GetUserByNameQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IFilters filters
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _filters = filters;
        }

        [Obsolete]
        public async Task<List<UserDto>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var resut = await _userRepository.FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            var listUsers = resut.Where(x => _filters.CheckString(x.DisplayName, request.Name)).ToList();
            if (!listUsers.Any())
                throw new NotFoundException($"Không tìm thấy thành viên nào có tên {request.Name}");

            return listUsers.MapToUserDtoToList(_mapper);
        }
    }
}
