using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.FilterManga
{
    public class FilterMangaQueryHandler : IRequestHandler<FilterMangaQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        private readonly IMangaTagRepository _tagRepository;    
        //private readonly IMangaSearchRepository _mangaSearchRepository;
        private readonly IMangaTagRepository _mangaTagRepository;    
        public FilterMangaQueryHandler(
            IMangaRepository mangaRepository,
            IMapper mapper,
            IFilters filters, 
            IMangaTagRepository tagRepository,  
            //IMangaSearchRepository mangaSearchRepository, 
            IMangaTagRepository mangaTagRepository)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
            _filters = filters;
            _tagRepository = tagRepository; 
            //_mangaSearchRepository = mangaSearchRepository;
            _mangaTagRepository = mangaTagRepository;
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
            int filerCount = 0;
            var query = _mangaRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);


            if (!string.IsNullOrEmpty(request.TagIds))
            {
                var tags = request.TagIds.Split(',').Select(x => x.Trim()).ToList();
                query = query.Where(x => tags.All(tagId => x.TagEntities!.Any(t => t.TagId.Trim() == tagId)));
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(x => x.Name.Trim().ToLower().Contains(request.Name.Trim().ToLower()));
                filerCount++;
            }
            if (request.Level != null)
            {
                query = query.Where(x=> x.Level == request.Level);
                filerCount++;
            }
            if(request.Status != null)
            {
                query = query.Where(x => x.Status == request.Status);
                filerCount++;
            }
            if(request.Type != null)
            {
                query = query.Where(x=> x.Type == request.Type);
                filerCount++;
            }
            if(request.Countries != null)
            {
                query = query.Where(x => x.Countries == request.Countries);
                filerCount++;
            }
            if(request.Season != null)
            {
                query = query.Where(x => x.Season == request.Season);
                filerCount++;
            }
            if(request.DateUpdate != null)
            {
                query = query.Where(x=> x.UpdateDate == request.DateUpdate);
                filerCount++;
            }
            if(request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
                filerCount++;
            }
            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
                filerCount++;
            }
            if (!string.IsNullOrEmpty(request.AuthorId))
            {
                query = query.Where(x => x.AuthorEntities.Any(a => a.AuthorId == request.AuthorId)); 
            }
            if (!string.IsNullOrEmpty(request.ArtistId))
            {
                query = query.Where(x => x.ArtistEntities.Any(a => a.ArtistId == request.ArtistId));
            }
            var listMangaExists = await _mangaRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);

            if (listMangaExists.Count() == 0)
                throw new NotFoundException("Không tìm thấy manga phù hợp yêu cầu");


            return listMangaExists.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
