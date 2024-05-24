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
    public class GetAllDeletedMangaRatingQueryHandler : IRequestHandler<GetAllDeletedMangaRatingQuery, ResponeResult<MangaRatingDto>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedMangaRatingQueryHandler(IMangaRatingRepository mangaRatingRepository, IMapper mapper)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _mapper = mapper;
        }
    
        public async Task<ResponeResult<MangaRatingDto>> Handle(GetAllDeletedMangaRatingQuery request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExists = await _mangaRatingRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (checkMangaRatingExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ MangaRating nào");
            }
            return new ResponeResult<MangaRatingDto>(checkMangaRatingExists.MapFullToMangaRatingDtoToList(_mapper));
        }
    }
}
