using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Chappter;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.Filter
{
    public class FilterChapterQueryHandler : IRequestHandler<FilterChapterQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public FilterChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChapterDto>> Handle(FilterChapterQuery request, CancellationToken cancellationToken)
        {
            var query = _chapterRepository.CreateQueryable();
            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);
            var listChapterExists = await _chapterRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(listChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bản ghi nào");
            }
            return listChapterExists.MapToPagedResult(x => x.MapFullToChapterDto(_mapper));
        }
        private IQueryable<ChapterEntity> ApplySorting(IQueryable<ChapterEntity> filter, FilterChapterQuery request)
        {
            return request.SortBy switch
            {
                ChapterSortBy.Index => OrderHelper.ApplyOrder(filter, x => x.Index, request.ReverseSort),
                ChapterSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.CreateDate, request.ReverseSort),
                ChapterSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities.Select(x => (double?)x.Rating).Average(), request.ReverseSort),
                ChapterSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.TotalCount, request.ReverseSort),
                ChapterSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities == null ? 0 : x.CommentEntities.Count, request.ReverseSort),
                _ => filter
            };
        }
        private IQueryable<ChapterEntity> ApplyFilter(IQueryable<ChapterEntity> query, FilterChapterQuery request)
        {
            if (request.Index != null) query = query.Where(x => x.Index == request.Index);
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);
            if (!string.IsNullOrEmpty(request.MangaName)) query = query.Where(x => x.MangaEntity.Name.Contains(request.MangaName));
            return query;
        }
    }
}
