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

namespace YAHALLO.Application.Commands.FollowCommand.Create
{
    public class CreateFollowMangaCommandHandler : IRequestHandler<CreateFollowMangaCommand, ResponeResult<string>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IFollowRepository _followRepository;
        public CreateFollowMangaCommandHandler(IMangaRepository mangaRepository, IUserRepository userRepository, ICurrentUserService currentUser,
            IFollowRepository followRepository)
        {
            _mangaRepository = mangaRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
            _followRepository = followRepository;
        }

        public async Task<ResponeResult<string>> Handle(CreateFollowMangaCommand request, CancellationToken cancellationToken)
        {
            var checkUserExist = await _userRepository
                .FindAsync(x => x.Id == request.UserId, cancellationToken);
            if(checkUserExist == null || !string.IsNullOrEmpty(checkUserExist.IdUserDelete) && checkUserExist.DeleteDate.HasValue)
            {
                throw new NotFoundException($"Không tìm thấy thành viên với Id {request.UserId} hoặc thành viên này đã bị khóa");
            }
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => x.Id == request.MangaId, cancellationToken);
            if (checkMangaExist == null || !string.IsNullOrEmpty(checkMangaExist.IdUserDelete) && checkMangaExist.DeleteDate.HasValue)
            {
                throw new NotFoundException($"Không tìm thấy manga với Id {request.MangaId} hoặc manga này đã bị vô hiệu");
            }
            var followManga = new FollowEntity
            {
                UserId = request.UserId,
                MangaId = request.MangaId,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now
            };
            _followRepository.Add(followManga);
            var result = await _followRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponeResult<string>(message: "Tạo thành công");
            }
            else
            {
                return new ResponeResult<string>(message: "Tạo thất bại");
            }
        }
    }
}
