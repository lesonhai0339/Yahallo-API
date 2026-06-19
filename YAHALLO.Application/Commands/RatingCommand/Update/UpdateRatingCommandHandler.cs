using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
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
            ArgumentOutOfRangeException.ThrowIfLessThan(request.Rating, 0);

            var rating = await _ratingRepository
                .FindAsync(x => x.Id == request.RatingId, cancellationToken);

            if (rating == null)
                throw new NotFoundException("Không tìm thấy MangaRating theo yêu cầu");

            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (rating.UserId != _currentUser.UserId && !isStaff)
                throw new UnauthorizedAccessException();

            rating.Rating = request.Rating;
            rating.UpdateDate = DateTime.UtcNow;
            rating.IdUserUpdate = _currentUser.UserId;
            _ratingRepository.Update(rating);
            var result = await _ratingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
