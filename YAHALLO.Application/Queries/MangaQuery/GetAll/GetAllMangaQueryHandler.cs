using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.UserEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetAll
{
    public class GetAllMangaQueryHandler : IRequestHandler<GetAllMangaQuery, ResponseResult<MangaDto>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;
        public GetAllMangaQueryHandler(IMangaRepository mangaRepository, IMapper mapper, ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<MangaDto>> Handle(GetAllMangaQuery request, CancellationToken cancellationToken)
        {
            UserLevel level= (UserLevel) Enum.Parse(typeof(UserLevel), _currentUser.Level!, true);
            if((int)level < 5)
            {
                return new ResponseResult<MangaDto>("Your Level does not eoungh to use this method");
            }
            var listMangaExists = await _mangaRepository
                .FindAllAsync(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(listMangaExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bất kỳ manga nào");
            }
            return new ResponseResult<MangaDto>(listMangaExists.MapFullToMangaDtoToList(_mapper));
        }
    }
}
