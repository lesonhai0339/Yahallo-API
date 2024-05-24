using AutoMapper;
using MediatR;
<<<<<<< HEAD
using Microsoft.Identity.Client;
=======
>>>>>>> master
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllPagination
{
    public class GetAllChapterPaginationQueryHandler : IRequestHandler<GetAllChapterPaginationQuery, PagedResult<ChapterDto>>
    {
<<<<<<< HEAD
        private readonly IChapterRepository _chaperRepository;
        private readonly IMapper _mapper;
        public GetAllChapterPaginationQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chaperRepository = chapterRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChapterDto>> Handle(GetAllChapterPaginationQuery request, CancellationToken cancellationToken)
        {
            var listChapterExists = await _chaperRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if(listChapterExists.Count()== 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ chương truyện nào");
            }
            return listChapterExists.MapToPagedResult(x=> x.MapFullToChapterDto(_mapper));  
=======
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;
        public GetAllChapterPaginationQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ChapterDto>> Handle(GetAllChapterPaginationQuery request, CancellationToken cancellationToken)
        {
            var checkChapterExists = await _chapterRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, request.PageNumber, request.PageSize, cancellationToken);
            if(checkChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất  kỳ chương truyện nào");
            }
            return checkChapterExists.MapToPagedResult(x => x.MapFullToChapterDto(_mapper));
>>>>>>> master
        }
    }
}
