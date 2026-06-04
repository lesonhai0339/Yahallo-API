using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.ChapterQuery.Filter
{
    public class FilterChapterQueryHandler : IRequestHandler<FilterChapterQuery, PagedResult<ChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        private readonly IFilters _filters;
        public FilterChapterQueryHandler(IChapterRepository chapterRepository, IMangaRepository mangaRepository, IMapper mapper, IFilters filters)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
            _filters = filters;
            _mangaRepository =mangaRepository;
        }
        public async Task<PagedResult<ChapterDto>> Handle(FilterChapterQuery request, CancellationToken cancellationToken)
        {
            var query = _chapterRepository.CreateQueryable();
            query = query.Where(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);    
            if(!string.IsNullOrEmpty(request.Id))
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if(request.Index != null)
            {
                query = query.Where(x=> x.Index == request.Index);  
            }
            if (!string.IsNullOrEmpty(request.MangaId))
            {
                query= query.Where(x=> x.MangaId == request.MangaId);   
            }
            if (!string.IsNullOrEmpty(request.MangaName))
            {
                query = query.Join(_mangaRepository.CreateQueryable(),
                    chapter => chapter.Id,
                    manga=> manga.Id,
                    (chapter,manga)=> new { Chapter= chapter, Manga=manga })
                    .Where(x=> x.Manga.Name.Equals(request.MangaName, StringComparison.OrdinalIgnoreCase))
                    .Select(x=> x.Chapter);
            }
            
            var listChapterExists= await _chapterRepository
                .FindAllAsync(query, request.PageNumber, request.PageSize, cancellationToken);
            if(listChapterExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bản ghi nào");
            }
            return listChapterExists.MapToPagedResult(x => x.MapFullToChapterDto(_mapper));
        }
    }
}
