using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Create
{
    public class CreateMangaRatingCommandHandler : IRequestHandler<CreateMangaRatingCommand, bool>
    {
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateMangaRatingCommandHandler(IMangaRatingRepository mangaRatingRepository, ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
            _mangaRatingRepository = mangaRatingRepository;
        }

        public async Task<bool> Handle(CreateMangaRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = await _mangaRatingRepository
                .FindAsync(x => x.MangaId == request.MangaId && x.UserId == request.UserId, cancellationToken);
            if(checkMangaRatingExist != null)
                throw new DuplicateException($"Đã tồn tại Manga Rating với MangaId và UserId trên");

            var newMangaRating = new MangaRatingEntity
            {
                MangaId = request.MangaId,
                UserId = request.UserId,
                Rating = request.Rating,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.UtcNow
            };
            _mangaRatingRepository.Add(newMangaRating);
            var result =   await _mangaRatingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
