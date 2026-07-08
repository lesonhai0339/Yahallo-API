using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Author.Filter
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

            if (!string.IsNullOrEmpty(request.Id)) query = query.Where(x => x.Id == request.Id);

            var name = request.Name?.Trim();
            if (!string.IsNullOrEmpty(name)) query = query.Where(x => x.Name.Contains(name));

            var authors = await _authorRepository
              .FindAllAsync(query,request.PageNo, request.PageSize, cancellationToken);

            return authors.MapToPagedResult(x => x.MapToAuthorDto(_mapper));
        }
    }
}
