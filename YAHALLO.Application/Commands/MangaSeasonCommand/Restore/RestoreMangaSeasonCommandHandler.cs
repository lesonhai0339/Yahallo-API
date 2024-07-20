using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Restore
{
    public class RestoreMangaSeasonCommandHandler : IRequestHandler<RestoreMangaSeasonCommand, ResponseResult<string>>
    {
        private readonly IMangaSeasonRepository _mangaSeasonRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreMangaSeasonCommandHandler(IMangaSeasonRepository mangaSeasonRepository, ICurrentUserService currentUser)
        {
            _mangaSeasonRepository = mangaSeasonRepository;
            _currentUser = currentUser;
        }
    
        public async Task<ResponseResult<string>> Handle(RestoreMangaSeasonCommand request, CancellationToken cancellationToken)
        {
            var checkMangaSeasonExist= await _mangaSeasonRepository
                .FindAsync(x=> x.Id.Equals(request.Id) && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken );
            if(checkMangaSeasonExist == null )
            {
                throw new NotFoundException($"Không có Manga season nào với Id: {request.Id} bị xóa");
            }
            checkMangaSeasonExist.DeleteDate = null;
            checkMangaSeasonExist.IdUserDelete = null;
            checkMangaSeasonExist.UpdateDate = DateTime.Now;
            checkMangaSeasonExist.IdUserUpdate = _currentUser.UserId;
            _mangaSeasonRepository.Update( checkMangaSeasonExist );
            var result= await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return new ResponseResult<string>("Phụ hồi thành công");
            }
            else
            {
                return new ResponseResult<string>("Phục hồi thất bại");
            }
        }
    }
}
