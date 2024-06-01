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
    public class CreateMangaRatingCommandHandler : IRequestHandler<CreateMangaRatingCommand, ResponseResult<string>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMangaRatingRepository _mangaRatingRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateMangaRatingCommandHandler(IMangaRepository mangaRepository, IUserRepository userRepository, IMangaRatingRepository mangaRatingRepository, ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
            _mangaRatingRepository = mangaRatingRepository;
        }

        public async Task<ResponseResult<string>> Handle(CreateMangaRatingCommand request, CancellationToken cancellationToken)
        {
            var checkMangaRatingExist = _mangaRatingRepository
                .FindAsync(x => x.MangaId == request.MangaId && x.UserId == request.UserId, cancellationToken);
            if(checkMangaRatingExist != null)
            {
                throw new DuplicateException($"Đã tồn tại Manga Rating với MangaId và UserId trên");
            }
            var newMangaRating = new MangaRatingEntity
            {
                MangaId = request.MangaId,
                UserId = request.UserId,
                Rating = request.Rating,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now
            };
            _mangaRatingRepository.Add(newMangaRating);
            var result =await _mangaRatingRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Tạo thành công");
            }
            else
            {
                return new ResponseResult<string>("Tạo thất bại");
            }
        }
    }
}
