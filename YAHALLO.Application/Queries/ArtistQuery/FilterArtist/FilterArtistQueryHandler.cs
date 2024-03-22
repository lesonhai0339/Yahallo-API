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

namespace YAHALLO.Application.Queries.ArtistQuery.FilterArtist
{
    public class FilterArtistQueryHandler : IRequestHandler<FilterArtistQuery, PagedResult<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterArtistQueryHandler(IArtistRepository artistRepository, IMapper mapper, IFilters filters)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _filters = filters;
        }

        public async Task<PagedResult<ArtistDto>> Handle(FilterArtistQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ArtistEntity>, IQueryable<ArtistEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                if (!string.IsNullOrEmpty(request.Id))
                {
                    query = query.Where(x => x.Id == request.Id);
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    var filters = _filters.CheckString(request.Name);
                    var predicate = PredicateBuilder.False<ArtistEntity>();
                    foreach (var filter in filters)
                    {
                        predicate = predicate.Or(x => x.Name.Contains(filter));
                    }
                    query= query.Where(predicate);
                }
                if (request.Countries != null)
                {
                    query = query.Where(x => x.Countries == request.Countries);
                }
                if (request.LifeStatus != null)
                {
                    query = query.Where(x => x.LifeStatus == request.LifeStatus);
                }
                return query;
            };

            var listArtists = await _artistRepository
                .FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!listArtists.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ họa sĩ nào");
            }
            return listArtists.MapToPagedResult(x => x.MapToArtistDto(_mapper));
        }
    }
}
