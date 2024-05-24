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

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAll
{
    public class GetAllMangaRatingQueryHandler : IRequestHandler<GetAllMangaRatingQuery, ResponeResult<MangaRatingDto>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly IMapper _mapper;
        public GetAllMangaRatingQueryHandler(IMangaRatingRepository mangaRatingRepository, IMapper mapper)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _mapper = mapper;
        }

        public async Task<ResponeResult<MangaRatingDto>> Handle(GetAllMangaRatingQuery request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExists = await _mangaRatingRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkMangaRatingExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy MangaRating nào");
            }
            var result = checkMangaRatingExists.MapFullToMangaRatingDtoToList(_mapper);
            return new ResponeResult<MangaRatingDto>(result);
        }
    }
}
