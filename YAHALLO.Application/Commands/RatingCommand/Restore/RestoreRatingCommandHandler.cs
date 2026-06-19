using MediatR;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Restore
{
    public class RestoreRatingCommandHandler : IRequestHandler<RestoreRatingCommand, bool>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreRatingCommandHandler(IRatingRepository ratingRepository, ICurrentUserService currentUser)
        {
            _ratingRepository = ratingRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(RestoreRatingCommand request, CancellationToken cancellationToken)
        {
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff) throw new UnauthorizedAccessException();

            var existed = request.RatingTo == RatingEnum.Manga
             ? await _ratingRepository.FindAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue && x.ToMangaId == request.TargetId && x.UserId == request.UserId, cancellationToken, ignoreQueryFilters: true)
             : request.RatingTo != RatingEnum.Chapter
             ? await _ratingRepository.FindAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue && x.ToChapterId == request.TargetId && x.UserId == request.UserId, cancellationToken, ignoreQueryFilters: true)
             : request.RatingTo == RatingEnum.User
             ? await _ratingRepository.FindAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue && x.ToUserId == request.TargetId && x.UserId == request.UserId, cancellationToken, ignoreQueryFilters: true)
             : null;

            if(existed == null)
                throw new NotFoundException("Không tìm thấy với các thông tin trên bị xóa");

            existed.DeleteDate = null;
            existed.IdUserDelete = null;
            existed.IdUserUpdate = _currentUser.UserId;
            existed.UpdateDate = DateTime.UtcNow;
            _ratingRepository.Update(existed);
            var result = await _ratingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
