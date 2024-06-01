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

namespace YAHALLO.Application.Commands.ChapterCommand.Delete
{
    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand, ResponseResult<string>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteChapterCommandHandler(IChapterRepository chapterRepository, ICurrentUserService currentUser)
        {
            _chapterRepository = chapterRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            var checkRole =await _currentUser.IsInRoleAsync("1");
            var checkChapterExist = await _chapterRepository
                .FindAsync
                (x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkChapterExist  == null)
            {
                throw new NotFoundException("Không tìm thấy chương truyện");
            }
            if(checkChapterExist.IdUserCreate != _currentUser.UserId || checkChapterExist.IdUserCreate != _currentUser.UserId && checkRole == false)
            {
                throw new UnAuthorizeException("Tài khoản hiện tại không có quyền thực hiện chức năng này");
            }
            checkChapterExist.IdUserDelete = _currentUser.UserId;
            checkChapterExist.DeleteDate = DateTime.Now;
            _chapterRepository.Update(checkChapterExist);
            var result= await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return new ResponseResult<string>(message: "Xóa thành công");
            }
            else
            {
                return new ResponseResult<string>(message: "Xóa thất bại");
            }
        }
    }
}
