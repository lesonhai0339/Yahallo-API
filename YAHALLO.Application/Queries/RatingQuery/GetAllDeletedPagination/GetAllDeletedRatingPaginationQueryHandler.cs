using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.MangaRatingQuery.GetAllPagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAllDeletedPagination
{
    public class GetAllDeletedRatingPaginationQueryHandler : IRequestHandler<GetAllDeletedRatingPaginationQuery, PagedResult<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedRatingPaginationQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<RatingDto>> Handle(GetAllDeletedRatingPaginationQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository
                 .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken, ignoreQueryFilters: true);
            if (!ratings.Any())
                throw new NotFoundException("Không tìm thấy MangaRating nào");

            return ratings.MapToPagedResult(x => x.MapFullToMangaRatingDto(_mapper));
        }
    }
}
