using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using YAHALLO.Domain.Common.Interfaces;
>>>>>>> master
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllDeleted
{
<<<<<<< HEAD
    public class GetAllDeletedChapterQueryHandler : IRequestHandler<GetAllDeletedChapterQuery, List<ChapterDto>>
=======
    public class GetAllDeletedChapterQueryHandler : IRequestHandler<GetAllDeletedChapterQuery, ResponeResult<ChapterDto>>
>>>>>>> master
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public GetAllDeletedChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }
<<<<<<< HEAD
        public async Task<List<ChapterDto>> Handle(GetAllDeletedChapterQuery request, CancellationToken cancellationToken)
        {
            var listChapterExists= await _chapterRepository
                .FindAllAsync(x=> !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue,cancellationToken);
            if(listChapterExists.Count() ==0)
            {
                throw new NotFoundException($"Không tìm tháy bất kỳ chương truyện nào bị xóa");
            }
            return listChapterExists.MapFullToChapterDtoToList(_mapper);
=======

        public async Task<ResponeResult<ChapterDto>> Handle(GetAllDeletedChapterQuery request, CancellationToken cancellationToken)
        {
            var checkChapterExists = await _chapterRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ chương truyện nào");
            }
            return new ResponeResult<ChapterDto>(entities: checkChapterExists.MapFullToChapterDtoToList(_mapper));
>>>>>>> master
        }
    }
}
