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

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Delete
{
    public class DeleteMangaSeasonCommandHandler : IRequestHandler<DeleteMangaSeasonCommand, ResponseResult<string>>
    {
        private readonly IMangaSeasonRepository _mangaSeasonRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteMangaSeasonCommandHandler(IMangaSeasonRepository mangaSeasonRepository, IMangaRepository mangaRepository, ICurrentUserService currentUser)
        {
            _mangaSeasonRepository = mangaSeasonRepository;
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(DeleteMangaSeasonCommand request, CancellationToken cancellationToken)
        {
            var checkMangaSeasonExist= await _mangaSeasonRepository
                .FindAsync(x=> x.Id.Equals(request.Id) && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue ,cancellationToken);
            if(checkMangaSeasonExist == null)
            {
                throw new NotFoundException("Không tồn tại Manga Season với Id này");
            }
            var checkMangaIncluding = checkMangaSeasonExist.MangaEntities.Count();
            if (checkMangaIncluding >0)
            {
                throw new Exception("Có Manga thuộc Manga Season này, không thể xóa");
            }
            checkMangaSeasonExist.DeleteDate = DateTime.Now;
            checkMangaSeasonExist.IdUserDelete = _currentUser.UserId;
            _mangaSeasonRepository.Update(checkMangaSeasonExist);
            var result= await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Xóa thành công");
            }
            else 
            { 
                return new ResponseResult<string>("Xóa thất bại");
            }
        }
    }
}
