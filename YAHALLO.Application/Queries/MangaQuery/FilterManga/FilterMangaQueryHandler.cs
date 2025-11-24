using AutoMapper;
using LinqKit;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Infrastructure.Elastic1.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.FilterManga
{
    public class FilterMangaQueryHandler : IRequestHandler<FilterMangaQuery, PagedResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        private readonly IElasticQueryBuilder<MangaEntity> _elasticQueryBuilder;    
        public FilterMangaQueryHandler(IMangaRepository mangaRepository, IMapper mapper, IFilters filters, IElasticQueryBuilder<MangaEntity> elasticQueryBuilder)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
            _filters = filters;
            _elasticQueryBuilder = elasticQueryBuilder;
        }

        public async Task<PagedResult<MangaDto>> Handle(FilterMangaQuery request, CancellationToken cancellationToken)
        {

            try
            {
                Expression<Func<MangaEntity, object>> querySearch = m => new
                {
                    m.Name
                };
                _elasticQueryBuilder.Match(querySearch, request.Name!);
                var result = await _elasticQueryBuilder.SearchAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Elastic search engine error");
            }

            var query = _mangaRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                var filters = _filters.CheckString(request.Name);
                var predicate = PredicateBuilder.New<MangaEntity>();
                foreach(var filter in filters)
                {
                    predicate = predicate.Or(x => x.Name.Contains(filter));
                }
                query = query.Where(predicate);
            }
            if(request.Level != null)
            {
                query = query.Where(x=> x.Level == request.Level);
            }
            if(request.Status != null)
            {
                query = query.Where(x => x.Status == request.Status);
            }
            if(request.Type != null)
            {
                query = query.Where(x=> x.Type == request.Type);
            }
            if(request.Countries != null)
            {
                query = query.Where(x => x.Countries == request.Countries);
            }
            if(request.Season != null)
            {
                query = query.Where(x => x.Season == request.Season);
            }
            if(request.DateUpdate != null)
            {
                query = query.Where(x=> x.UpdateDate == request.DateUpdate);
            }
            if(request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            var listMangaExists = await _mangaRepository
                .FindAllAsync(query, request.PageNumber, request.PageSizee, cancellationToken);
            if(listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy manga phù hợp yêu cầu");
            }
            return listMangaExists.MapToPagedResult(x => x.MapFullToMangaDto(_mapper));
        }
    }
}
