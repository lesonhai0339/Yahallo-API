using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Create
{
    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, string>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateRatingCommandHandler(IRatingRepository ratingRepository, ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
            _ratingRepository = ratingRepository;
        }

        public async Task<string> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {

            var existed = request.RatingTo == RatingEnum.Manga
                ? await _ratingRepository.FindAsync(x => x.ToMangaId == request.TargetId && x.UserId == request.UserId, cancellationToken)
                : request.RatingTo != RatingEnum.Chapter
                ? await _ratingRepository.FindAsync(x => x.ToChapterId == request.TargetId && x.UserId == request.UserId, cancellationToken)
                : request.RatingTo == RatingEnum.User
                ? await _ratingRepository.FindAsync(x => x.ToUserId == request.TargetId && x.UserId == request.UserId, cancellationToken)
                : null;
            if (existed != null)
                throw new DuplicateException($"Existed rating on {request.RatingTo} - Id: {existed.Id}");

            var rating = new RatingEntity
            {
                UserId = request.UserId,
                Rating = request.Rating,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.UtcNow
            };
            if(request.RatingTo == RatingEnum.Manga)
                rating.ToMangaId = request.TargetId;

            if (request.RatingTo == RatingEnum.Chapter)
                rating.ToChapterId = request.TargetId;

            if (request.RatingTo == RatingEnum.User)
                rating.UserId = request.TargetId;

            _ratingRepository.Add(rating);
            var result =   await _ratingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0 ? rating.Id : string.Empty;
        }
    }
}
