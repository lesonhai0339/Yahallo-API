//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Tag;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Tag.FilterTag
{
    public class FilterTagQueryHandler : IRequestHandler<FilterTagQuery, PagedResult<TagDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public FilterTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TagDto>> Handle(FilterTagQuery request, CancellationToken cancellationToken)
        {
            var query = _tagRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete));

            if (!string.IsNullOrEmpty(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            var paged = await _tagRepository.FindAllAsync(query, request.PageNo, request.PageSize, cancellationToken);

            if (!paged.Any())
                throw new NotFoundException("Không tìm thấy tag phù hợp");

            return paged.MapToPagedResult(x => x.MapToTagDto(_mapper));
        }
    }
}
