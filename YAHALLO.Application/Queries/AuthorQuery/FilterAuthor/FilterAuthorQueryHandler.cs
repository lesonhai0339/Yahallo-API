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

namespace YAHALLO.Application.Queries.AuthorQuery.FilterAuthor
{
    public class FilterAuthorQueryHandler : IRequestHandler<FilterAuthorQuery, PagedResult<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper, IFilters filters)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _filters = filters;
        }
        public async Task<PagedResult<AuthorDto>> Handle(FilterAuthorQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<AuthorEntity>, IQueryable<AuthorEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                if (!string.IsNullOrEmpty(request.Id))
                {
                    query = query.Where(x => x.Id == request.Id);
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    var filtervalue = _filters.CheckString(request.Name);
                    var predicate = PredicateBuilder.False<AuthorEntity>();
                    foreach (var filter in filtervalue)
                    {
                        predicate = predicate.Or(x => x.Name == filter);
                    }
                    query.Where(predicate);
                }
                if (request.Countries != null)
                {
                    query = query.Where(x => x.Countries == request.Countries);
                }
                if (request.Birth != null)
                {
                    query = query.Where(x => x.Birth == request.Birth);
                }
                if (request.LifeStatus != null)
                {
                    query = query.Where(x => x.LifeStatus == request.LifeStatus);
                }
                return query;
            };

            var listAuthorExists = await _authorRepository
                .FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!listAuthorExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ tác giả nào");
            }
            return listAuthorExists.MapToPagedResult(x => x.MapToAuthorDto(_mapper));
        }
    }
}
