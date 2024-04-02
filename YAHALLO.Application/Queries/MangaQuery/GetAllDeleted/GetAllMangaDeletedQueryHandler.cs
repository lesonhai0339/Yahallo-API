using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetAllDeleted
{
    public class GetAllMangaDeletedQueryHandler : IRequestHandler<GetAllMangaDeletedQuery, List<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        public GetAllMangaDeletedQueryHandler(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }

        public async Task<List<MangaDto>> Handle(GetAllMangaDeletedQuery request, CancellationToken cancellationToken)
        {
            var listMangaExists = await _mangaRepository
                .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không có bất kỳ manga nào");
            }
            return listMangaExists.MapFullToMangaDtoToList(_mapper);
        }
    }
}
