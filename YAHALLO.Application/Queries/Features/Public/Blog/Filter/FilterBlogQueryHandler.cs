using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Blog.Filter
{
    public class FilterBlogQueryHandler : IRequestHandler<FilterBlogQuery, PagedResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public FilterBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
    
        public async Task<PagedResult<BlogDto>> Handle(FilterBlogQuery request, CancellationToken cancellationToken)
        {
            var query = _blogRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.BlogId))
            {
                query = query.Where(x=> x.Id == request.BlogId);
            }
            if (!string.IsNullOrEmpty(request.ParentId))
            {
                query = query.Where(x=> x.ParentId == request.ParentId);
            }
            var orderCriteria = new List<(Expression<Func<BlogEntity, object>> keySelector, bool ascending)>();
            if (request.Like != null)
            {
                orderCriteria.Add((x => x.Like, request.Like.Value));
            }

            if (request.Dislike != null)    
            {
                orderCriteria.Add((x => x.DisLike, request.Dislike.Value));
            }

            if (request.ViewCount != null)
            {
                orderCriteria.Add((x => x.ViewCount!, request.ViewCount.Value));
            }
            IEnumerable<BlogEntity>? orderedQuery = null;
            foreach (var (keySelector, ascending) in orderCriteria)
            {
                if (orderedQuery == null)
                {
                    orderedQuery = ascending
                        ? query.OrderBy(keySelector)
                        : query.OrderByDescending(keySelector);
                }
                else
                {
                    orderedQuery = ascending
                          ? ((IOrderedQueryable<BlogEntity>)orderedQuery).ThenBy(keySelector)
                          : ((IOrderedQueryable<BlogEntity>)orderedQuery).ThenByDescending(keySelector);
                }
            }
            if (string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(x=> x.Title == request.Title);
            }
            if(request.Status != null)
            {
                query = query.Where(x=> x.Status == request.Status);
            }
            if(request.Type != null)
            {
                query = query.Where(x=> x.Type == request.Type);    
            }
            if(orderedQuery != null)
            {
                query.Intersect(orderedQuery);
            }
            var result = await _blogRepository.FindAllAsync(query, request.PageNo, request.PageSize, cancellationToken);
            if(result.Count() == 0)
            {
                throw new NotFoundException("Does not exist any Blog matches");
            }
            return result.MapToPagedResult(x => x.MapToBlogDto(_mapper));
        }
    }
}
