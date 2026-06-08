using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.FilterManga
{
    public class FilterMangaQueryHandler : IRequestHandler<FilterMangaQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        //private readonly IMangaSearchRepository _mangaSearchRepository;
        public FilterMangaQueryHandler(
            IMangaRepository mangaRepository,
            IMapper mapper
            //IMangaSearchRepository mangaSearchRepository,
            )
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
            //_mangaSearchRepository = mangaSearchRepository;
        }

        public async Task<PagedResult<MangaDto>> Handle(FilterMangaQuery request, CancellationToken cancellationToken)
        {

            //try
            //{
            //    Action<QueryDescriptor<MangaEntity>> action = new Action<QueryDescriptor<MangaEntity>>((q) =>
            //    {
            //        q.Match(m =>
            //        {
            //            m.Field(f => f.Name).Query(request.Name!);
            //        });
            //    });
            //    IQuery<MangaEntity> queryable;
            //}
            //catch(Exception ex)
            //{
            //    Log.Error(ex, "Elastic search engine error");
            //}

            var query = _mangaRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);

            query = ApplyFilter(query, request);
            query = ApplySorting(query, request);

            var listMangaExists = await _mangaRepository.FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);

            if (listMangaExists.Count() == 0)
                throw new NotFoundException("Không tìm thấy manga phù hợp yêu cầu");

            return listMangaExists.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
        private IQueryable<MangaEntity> ApplySorting(IQueryable<MangaEntity> filter, FilterMangaQuery request)
        {
            return request.SortBy switch
            {
                MangaSortBy.LastUpdate => OrderHelper.ApplyOrder(filter, x => x.LastChapterUpdate, request.ReverserSort),
                MangaSortBy.Rating => OrderHelper.ApplyOrder(filter, x => x.RatingEntities == null ? 0 : x.RatingEntities.Average(x => x.Rating), request.ReverserSort),
                MangaSortBy.ViewCount => OrderHelper.ApplyOrder(filter, x => x.ViewCount == null ? 0 : x.ViewCount.ViewCount, request.ReverserSort),
                MangaSortBy.CommentCount => OrderHelper.ApplyOrder(filter, x => x.CommentEntities == null ? 0 : x.CommentEntities.Count, request.ReverserSort),
                MangaSortBy.ChapterCount => OrderHelper.ApplyOrder(filter, x => x.ChaptersEntities == null ? 0 : x.ChaptersEntities.Count, request.ReverserSort),
                _=> filter
            };
        }
        private IQueryable<MangaEntity> ApplyFilter(IQueryable<MangaEntity> query, FilterMangaQuery request)
        {
            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.Name.Trim().ToLower().Contains(request.Name.Trim().ToLower()));
            if (request.Level != null) query = query.Where(x => x.Level == request.Level);
            if (request.Status != null)  query = query.Where(x => x.Status == request.Status);
            if (request.Type != null)query = query.Where(x => x.Type == request.Type);
            if (request.Countries != null) query = query.Where(x => x.Countries == request.Countries);
            if (request.Season != null)query = query.Where(x => x.Season == request.Season);
            if (request.DateUpdate != null) query = query.Where(x => x.UpdateDate == request.DateUpdate);
            if (request.UserId != null) query = query.Where(x => x.UserId == request.UserId);
            if (!string.IsNullOrEmpty(request.Id))query = query.Where(x => x.Id == request.Id);
            if (!string.IsNullOrEmpty(request.AuthorId)) query = query.Where(x => x.AuthorEntities.Any(a => a.AuthorId == request.AuthorId));
            if (!string.IsNullOrEmpty(request.ArtistId))query = query.Where(x => x.ArtistEntities.Any(a => a.ArtistId == request.ArtistId));
            if (!string.IsNullOrEmpty(request.TagIds))
            {
                var tags = request.TagIds.Split(',').Select(x => x.Trim()).ToList();
                query = query.Where(x => tags.All(tagId => x.TagEntities!.Any(t => t.TagId.Trim() == tagId)));
            }
            return query;
        }
    }
}
