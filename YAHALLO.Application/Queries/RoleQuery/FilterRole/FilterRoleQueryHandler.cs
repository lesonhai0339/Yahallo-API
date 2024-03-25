using AutoMapper;
using LinqKit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.RoleQuery.FilterRole
{
    public class FilterRoleQueryHandler : IRequestHandler<FilterRoleQuery, PagedResult<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper, IFilters filters)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _filters = filters;
        }

        public async Task<PagedResult<RoleDto>> Handle(FilterRoleQuery request, CancellationToken cancellationToken)
        {
            var query = _roleRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if(request.RoleCode != null)
            {
                query = query.Where(x => x.RoleCode == request.RoleCode);
            }
            if (!string.IsNullOrEmpty(request.RoleName))
            {
                var filters = _filters.CheckString(request.RoleName);
                var predicate = PredicateBuilder.New<RoleEntity>();
                foreach(var filter in filters)
                {
                    predicate = predicate.Or(x => x.RoleName.Contains(filter));
                }
                query = query.Where(predicate);
            }
            var listRoleExists= await _roleRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if (!listRoleExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ role nào");
            }
            return listRoleExists.MapToPagedResult(x => x.MapToRoleDto(_mapper));
        }
    }
}
