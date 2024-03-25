using AutoMapper;
using LinqKit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var query = _authorRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Id))
            {
                var pro= typeof(FilterAuthorQuery).GetProperty(nameof(request.Id));
                var expression = _authorRepository.IExpressionMultiple(pro!, request.Id, Expression.Equal);
                if(expression != null) query = query.Where(expression);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                var predicate = PredicateBuilder.New<AuthorEntity>();
                var filters = _filters.CheckString(request.Name);
                foreach(var filter in filters)
                {
                    predicate = predicate.Or(x => x.Name.Contains(filter));
                }
                query = query.Where(predicate);
            }
            if(request.Countries != null)
            {
                var pro = typeof(FilterAuthorQuery).GetProperty(nameof(request.Countries));
                var expression = _authorRepository.IExpressionMultiple(pro!, request.Countries, Expression.Equal);
                if (expression != null) query = query.Where(expression);
            }
            if (request.Birth != null)
            {
                var pro = typeof(FilterAuthorQuery).GetProperty(nameof(request.Birth));
                var expression = _authorRepository.IExpressionMultiple(pro!, request.Birth, Expression.Equal);
                if (expression != null) query = query.Where(expression);
            }
            if (request.LifeStatus != null)
            {
                var pro = typeof(FilterAuthorQuery).GetProperty(nameof(request.LifeStatus));
                var expression = _authorRepository.IExpressionMultiple(pro!, request.LifeStatus, Expression.Equal);
                if (expression != null) query = query.Where(expression);
            }

            var listAuthorExists = await _authorRepository
              .FindAllAsync(query,request.PageNumber, request.PageSize, cancellationToken);
            if (!listAuthorExists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ tác giả nào");
            }
            return listAuthorExists.MapToPagedResult(x => x.MapToAuthorDto(_mapper));
        }
    }
}
