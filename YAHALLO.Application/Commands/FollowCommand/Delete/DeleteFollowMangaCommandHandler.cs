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

namespace YAHALLO.Application.Commands.FollowCommand.Delete
{
    public class DeleteFollowMangaCommandHandler : IRequestHandler<DeleteFollowMangaCommand, ResponeResult<string>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteFollowMangaCommandHandler(IFollowRepository followRepository, ICurrentUserService currentUser)
        {
            _followRepository = followRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponeResult<string>> Handle(DeleteFollowMangaCommand request, CancellationToken cancellationToken)
        {
            var checkFollowExist = await _followRepository
                .FindAsync(x => x.UserId == request.UserId && x.MangaId == request.MangaId
                & string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkFollowExist == null)
            {
                throw new NotFoundException($"Không tìm thấy bản ghi nào với User Id: {request.UserId} và Manga Id: {request.MangaId}");
            }
            checkFollowExist.DeleteDate = DateTime.Now;
            checkFollowExist.IdUserDelete = _currentUser.UserId;
            _followRepository.Update(checkFollowExist);
            var result = await _followRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return new ResponeResult<string>(message: "Xóa thành công");
            }
            else
            {
                return new ResponeResult<string>(message: "Xóa thất bại");
            }
        }
    }
}
