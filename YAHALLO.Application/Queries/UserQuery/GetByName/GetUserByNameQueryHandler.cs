using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Application.Queries.UserQuery.GetByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        private readonly ApplicationDbContext _context;
        public GetUserByNameQueryHandler(
            IUserRepository userRepository, 
            IMapper mapper, 
            IFilters filters,
            ApplicationDbContext context
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _filters = filters;
            _context = context;
        }
        public async Task<List<UserDto>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (!users.Any())
            {
                throw new NotFoundException("Không tìm thấy thành viên nào");
            }
            var listUsers = users.Where(x => _filters.CheckString(x.DisplayName, request.Name) || _filters.CheckString(x.FirstName + x.LastName, request.Name)).ToList();
            //Expression<Func<UserEntity, bool>> predicate = query => _filters.CheckString(query.DisplayName, request.Name);
            //var listUsers = await _userRepository
            //    .FindAllAsync(predicate, cancellationToken);
            if (!listUsers.Any())
            {
                throw new NotFoundException($"Không tìm thấy thành viên nào có tên {request.Name}");
            }
            return listUsers.MapToUserDtoToList(_mapper);
        }
    }
}
