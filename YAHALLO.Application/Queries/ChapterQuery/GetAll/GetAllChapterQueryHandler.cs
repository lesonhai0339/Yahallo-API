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

namespace YAHALLO.Application.Queries.ChapterQuery.GetAll
{
    public class GetAllChapterQueryHandler : IRequestHandler<GetAllChapterQuery, ResponseResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public GetAllChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }
        public async Task<ResponseResult<ChapterDto>> Handle(GetAllChapterQuery request, CancellationToken cancellationToken)
        {
            var checkChapterExists = await _chapterRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ chương truyện nào");
            }
            return new ResponseResult<ChapterDto>(entities: checkChapterExists.MapFullToChapterDtoToList(_mapper));
        }
    }
}
