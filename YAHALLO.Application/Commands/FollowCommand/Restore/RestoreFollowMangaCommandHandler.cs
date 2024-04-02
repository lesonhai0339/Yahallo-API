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

namespace YAHALLO.Application.Commands.FollowCommand.Restore
{
    public class RestoreFollowMangaCommandHandler : IRequestHandler<RestoreFollowMangaCommand, ResponeResult>
    {
        private readonly IFollowRepository _followRepository;
        private readonly ICurrentUserService _currentUserService;
        public RestoreFollowMangaCommandHandler(IFollowRepository followRepository, ICurrentUserService currentUserService)
        {
            _followRepository = followRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ResponeResult> Handle(RestoreFollowMangaCommand request, CancellationToken cancellationToken)
        {
            var checkFollowMangaExist= await _followRepository
                .FindAsync(x=> x.UserId == request.UserId && x.MangaId == request.MangaId
                && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkFollowMangaExist == null)
            {
                throw new NotFoundException("Không tìm thấy bản ghi nào phù hợp");
            }
            checkFollowMangaExist.DeleteDate = null;
            checkFollowMangaExist.IdUserDelete = null;
            checkFollowMangaExist.UpdateDate = DateTime.Now;
            checkFollowMangaExist.IdUserUpdate = _currentUserService.UserId;
            _followRepository.Update(checkFollowMangaExist);
            var result = await _followRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponeResult(message: "Phục hồi thành công");
            }
            else
            {
                return new ResponeResult(message: "Phục hồi thất bại");
            }
        }
    }
}
