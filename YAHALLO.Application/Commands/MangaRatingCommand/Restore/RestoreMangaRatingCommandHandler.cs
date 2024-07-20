using Azure;
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

namespace YAHALLO.Application.Commands.MangaRatingCommand.Restore
{
    public class RestoreMangaRatingCommandHandler : IRequestHandler<RestoreMangaRatingCommand, ResponseResult<string>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreMangaRatingCommandHandler(IMangaRatingRepository mangaRatingRepository, ICurrentUserService currentUser)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(RestoreMangaRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = await _mangaRatingRepository
                .FindAsync(x => x.MangaId == request.MangaId && x.UserId == request.UserId && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkMangaRatingExist == null)
            {
                throw new NotFoundException("Không tìm thấy với các thông tin trên bị xóa");
            }
            checkMangaRatingExist.DeleteDate = null;
            checkMangaRatingExist.IdUserDelete = null;
            checkMangaRatingExist.IdUserUpdate = _currentUser.UserId;
            checkMangaRatingExist.UpdateDate = DateTime.Now;
            _mangaRatingRepository.Update(checkMangaRatingExist);
            var result = await _mangaRatingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseResult<string>("Phục hồi thành công");
            }
            else
            {
                return new ResponseResult<string>("Phục hồi thất bại");
            }
        }
    }
}
