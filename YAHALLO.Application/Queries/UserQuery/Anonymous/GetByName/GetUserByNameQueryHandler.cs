using AutoMapper;
using LinqKit;
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

namespace YAHALLO.Application.Queries.UserQuery.Anonymous.GetByName
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
            //var listDuplicate = _filters.CheckString(request.Name);
            //Func<IQueryable<UserEntity>, IQueryable<UserEntity>> options = query =>
            //{
            //    query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            //    var predicate = PredicateBuilder.False<UserEntity>();
            //    foreach (var item in listDuplicate)
            //    {
            //        predicate = predicate.Or(x => x.DisplayName!.Contains(item) || (x.FirstName + x.LastName).Contains(item));
            //    }
            //    query = query.Where(predicate);
            //    return query;
            //};  
            //var listUsers = await _userRepository
            //    .FindAllAsync(options, cancellationToken);
            var resut = await _userRepository.FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            var listUsers = resut.Where(x => _filters.CheckString(x.DisplayName, request.Name)).ToList();
            if (!listUsers.Any())
            {
                throw new NotFoundException($"Không tìm thấy thành viên nào có tên {request.Name}");
            }
            return listUsers.MapToUserDtoToList(_mapper);
        }
    }
}
