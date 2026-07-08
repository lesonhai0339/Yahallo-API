using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Rating;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Rating.GetAll
{
    public class GetAllRatingQueryHandler : IRequestHandler<GetAllRatingQuery, ResponseResult<RatingDto>>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public GetAllRatingQueryHandler(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }

        public async Task<ResponseResult<RatingDto>> Handle(GetAllRatingQuery request, CancellationToken cancellationToken)
        {
            var ratings = await _ratingRepository
                .FindAllAsync(cancellationToken);
            if(!ratings.Any())
                throw new NotFoundException("Không tìm thấy MangaRating nào");

            var result = ratings.MapFullToMangaRatingDtoToList(_mapper);
            return new ResponseResult<RatingDto>(result);
        }
    }
}
