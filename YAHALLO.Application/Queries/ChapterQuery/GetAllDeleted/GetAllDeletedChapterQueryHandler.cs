using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllDeleted
{
    public class GetAllDeletedChapterQueryHandler : IRequestHandler<GetAllDeletedChapterQuery, List<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }
        public async Task<List<ChapterDto>> Handle(GetAllDeletedChapterQuery request, CancellationToken cancellationToken)
        {
            var listChapterExists= await _chapterRepository
                .FindAllAsync(x=> !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue,cancellationToken);
            if(listChapterExists.Count() ==0)
            {
                throw new NotFoundException($"Không tìm tháy bất kỳ chương truyện nào bị xóa");
            }
            return listChapterExists.MapFullToChapterDtoToList(_mapper);
        }
    }
}
