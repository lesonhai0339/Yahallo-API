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

namespace YAHALLO.Application.Commands.MangaRatingCommand.Delete
{
    public class DeleteMangaRatingCommandHandler : IRequestHandler<DeleteMangaRatingCommand, bool>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteMangaRatingCommandHandler(IMangaRatingRepository mangaRatingRepository, ICurrentUserService curreentUser)
        {
            _mangaRatingRepository = mangaRatingRepository;
            _currentUser = curreentUser;
        }

        public async Task<bool> Handle(DeleteMangaRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = await _mangaRatingRepository
                .FindAsync(x => x.MangaId == request.MangaId && x.UserId == request.UserId, cancellationToken);
            if(checkMangaRatingExist == null)
                throw new NotFoundException("Không tìm thấy MangaRating với thông tin trên");

            if (!string.IsNullOrEmpty(checkMangaRatingExist.IdUserDelete) && checkMangaRatingExist.DeleteDate.HasValue)
                throw new DuplicateException("Đã tồn tại MangaRating nhưng đã bị xóa trước đó");

            checkMangaRatingExist.DeleteDate = DateTime.Now;
            checkMangaRatingExist.IdUserDelete = _currentUser.UserId;
            _mangaRatingRepository.Update(checkMangaRatingExist);
            var result = await _mangaRatingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
