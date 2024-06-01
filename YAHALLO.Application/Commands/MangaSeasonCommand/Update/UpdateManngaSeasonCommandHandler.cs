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

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Update
{
    public class UpdateManngaSeasonCommandHandler : IRequestHandler<UpdateManngaSeasonCommand, ResponseResult<string>>
    {
        private readonly IMangaSeasonRepository _mangaSeasonRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateManngaSeasonCommandHandler(IMangaSeasonRepository mangaSeasonRepository, ICurrentUserService currentUser)
        {
            _mangaSeasonRepository = mangaSeasonRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(UpdateManngaSeasonCommand request, CancellationToken cancellationToken)
        {
            var checkMangaSeasonExist= await _mangaSeasonRepository
                .FindAsync(x=> x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkMangaSeasonExist == null)
            {
                throw new NotFoundException($"Không tìm thấy Manga season với Id: {request.Id}");
            }
            checkMangaSeasonExist.Description = request.Description ?? checkMangaSeasonExist.Description;
            checkMangaSeasonExist.UpdateDate = DateTime.Now;
            checkMangaSeasonExist.IdUserUpdate= _currentUser.UserId;
            _mangaSeasonRepository.Update(checkMangaSeasonExist);
            var result= await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result>0)
            {
                return new ResponseResult<string>("Cập nhật thành công");
            }
            else
            {
                return new ResponseResult<string>("Cập nhật thất bại");
            }
        }
    }
}
