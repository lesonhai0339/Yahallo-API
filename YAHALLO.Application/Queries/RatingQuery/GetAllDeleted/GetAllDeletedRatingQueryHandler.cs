using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAllDeleted
{
    public class GetAllDeletedRatingQueryHandler : IRequestHandler<GetAllDeletedRatingQuery, ResponseResult<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedRatingQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
    
        public async Task<ResponseResult<RatingDto>> Handle(GetAllDeletedRatingQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken, ignoreQueryFilters: true);
            if (!ratings.Any())
                throw new NotFoundException("Không tìm thấy bất kỳ MangaRating nào");

            return new ResponseResult<RatingDto>(ratings.MapFullToMangaRatingDtoToList(_mapper));
        }
    }
}
