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

namespace YAHALLO.Application.Commands.MangaRatingCommand.Update
{
    public class UpdateMangaRatingCommandHandler : IRequestHandler<UpdateMangaRatingCommand, ResponeResult<string>>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateMangaRatingCommandHandler(IMangaRatingRepository mangaRatingRepository, ICurrentUserService currentUser)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponeResult<string>> Handle(UpdateMangaRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = await _mangaRatingRepository
                .FindAsync(x => x.MangaId == request.MangaId && x.UserId == request.UserId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkMangaRatingExist == null)
            {
                throw new NotFoundException("Không tìm thấy MangaRating theo yêu cầu");
            }
            checkMangaRatingExist.Rating = (request.Rating==0) ? request.Rating : checkMangaRatingExist.Rating;
            checkMangaRatingExist.UpdateDate = DateTime.Now;
            checkMangaRatingExist.IdUserUpdate = _currentUser.UserId;
            _mangaRatingRepository.Update(checkMangaRatingExist);
            var result = await _mangaRatingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return new ResponeResult<string>("Cập nhật thành công");
            }
            else
            {
                return new ResponeResult<string>("Cập nhật thất bại");
            }
        }
    }
}
