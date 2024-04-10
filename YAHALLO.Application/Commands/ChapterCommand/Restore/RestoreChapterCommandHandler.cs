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

namespace YAHALLO.Application.Commands.ChapterCommand.Restore
{
    public class RestoreChapterCommandHandler : IRequestHandler<RestoreChapterCommand, ResponeResult>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreChapterCommandHandler(IChapterRepository chapterRepository, ICurrentUserService currentUser)
        {
            _chapterRepository = chapterRepository;
            _currentUser = currentUser;
        }
    
        public async Task<ResponeResult> Handle(RestoreChapterCommand request, CancellationToken cancellationToken)
        {
            var checkRole = await _currentUser.IsInRoleAsync("1");
            var checkChapterExist = await _chapterRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (checkChapterExist == null)
            {
                throw new NotFoundException($"Không có chương truyện nào với Id {request.Id}");
            }
            if(checkChapterExist.IdUserCreate != _currentUser.UserId || checkChapterExist.IdUserCreate != _currentUser.UserId && checkRole == false)
            {
                throw new UnAuthorizeException("Bạn không có quyền để thực hiện chức năng này");
            }
            checkChapterExist.IdUserDelete = null;
            checkChapterExist.DeleteDate = null;
            checkChapterExist.UpdateDate = DateTime.Now;
            checkChapterExist.IdUserUpdate = _currentUser.UserId;
            _chapterRepository.Update(checkChapterExist);
            var result = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
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
