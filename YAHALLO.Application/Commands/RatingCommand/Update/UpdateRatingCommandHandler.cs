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
    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, bool>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateRatingCommandHandler(IRatingRepository ratingRepository, ICurrentUserService currentUser)
        {
            _ratingRepository = ratingRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = await _ratingRepository
                .FindAsync(x => x.Id == request.RatingId, cancellationToken);
            if(checkMangaRatingExist == null)
                throw new NotFoundException("Không tìm thấy MangaRating theo yêu cầu");

            checkMangaRatingExist.Rating = (request.Rating==0) ? request.Rating : checkMangaRatingExist.Rating;
            checkMangaRatingExist.UpdateDate = DateTime.Now;
            checkMangaRatingExist.IdUserUpdate = _currentUser.UserId;
            _ratingRepository.Update(checkMangaRatingExist);
            var result = await _ratingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
