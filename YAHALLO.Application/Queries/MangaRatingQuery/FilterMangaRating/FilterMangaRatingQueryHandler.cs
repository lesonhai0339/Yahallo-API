using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

namespace YAHALLO.Application.Queries.MangaRatingQuery.FilterMangaRating
{
    public class FilterMangaRatingQueryHandler : IRequestHandler<FilterMangaRatingQuery, PagedResult<MangaRatingDto>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filter;
        private readonly IMangaRepository _mangaRepository;
        private readonly IUserRepository _userRepository;
        public FilterMangaRatingQueryHandler(IMangaRatingRepository mangaRatingRepository, IMapper mapper, IFilters filter, IMangaRepository mangaRepository, IUserRepository userRepository)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _mapper = mapper;
            _filter = filter;
            _mangaRepository = mangaRepository;
            _userRepository = userRepository;
        }

        public async Task<PagedResult<MangaRatingDto>> Handle(FilterMangaRatingQuery request, CancellationToken cancellationToken)
        {
            var query = _mangaRatingRepository.CreateQueryable();
            query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
            if (!string.IsNullOrEmpty(request.MangaId))
            {
                query = query.Where(x => x.MangaId == request.MangaId);
            }
            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.UserId == request.UserId);
            }
            if (!string.IsNullOrEmpty(request.MangaName))
            {
                var filters= _filter.CheckString(request.MangaName);
                var predicate = PredicateBuilder.New<MangaRatingEntity>();
                foreach(var filter in filters)
                {
                    predicate = predicate.Or(x => EF.Functions.Contains(filters, x.Manga.Name));
                }
                query = query.Where(predicate);
            }
            if (!string.IsNullOrEmpty(request.UserName))
            {
                var filters = _filter.CheckString(request.UserName);
                var predicate = PredicateBuilder.New<MangaRatingEntity>();
                foreach (var filter in filters)
                {
                    predicate = predicate.Or(x => x.User.DisplayName!.Contains(filter));
                }
                query = query.Where(predicate);
            }
            var listMangaRating = await _mangaRatingRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(listMangaRating.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ MangaRating nào phù hợp");
            }
            return listMangaRating.MapToPagedResult(x => x.MapFullToMangaRatingDto(_mapper));
        }
    }
}
