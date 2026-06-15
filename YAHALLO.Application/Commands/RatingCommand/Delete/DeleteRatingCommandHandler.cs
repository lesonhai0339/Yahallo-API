using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Delete
{
    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, bool>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteRatingCommandHandler(IRatingRepository ratingRepository, ICurrentUserService curreentUser)
        {
            _ratingRepository = ratingRepository;
            _currentUser = curreentUser;
        }

        public async Task<bool> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var existed = request.RatingTo == RatingEnum.Manga
              ? await _ratingRepository.FindAsync(x => x.ToMangaId == request.TargetId && x.UserId == request.UserId, cancellationToken)
              : request.RatingTo != RatingEnum.Chapter
              ? await _ratingRepository.FindAsync(x => x.ToChapterId == request.TargetId && x.UserId == request.UserId, cancellationToken)
              : request.RatingTo == RatingEnum.User
              ? await _ratingRepository.FindAsync(x => x.ToUserId == request.TargetId && x.UserId == request.UserId, cancellationToken)
              : null;

            if(existed == null)
                throw new NotFoundException("Không tìm thấy MangaRating với thông tin trên");

            existed.DeleteDate = DateTime.Now;
            existed.IdUserDelete = _currentUser.UserId;

            _ratingRepository.Update(existed);
            var result = await _ratingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
