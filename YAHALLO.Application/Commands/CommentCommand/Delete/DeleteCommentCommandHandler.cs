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

namespace YAHALLO.Application.Commands.CommentCommand.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ResponseResult<string>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository, ICurrentUserService currentUser)
        {
            _commentRepository = commentRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var checkCommentExist= await _commentRepository.FindAsync(x=> x.Id.Equals(request.Id), cancellationToken);
            if(checkCommentExist == null)
            {
                throw new NotFoundException("Không tồn tại comment với Id này");
            }
            if(!string.IsNullOrEmpty(checkCommentExist.IdUserDelete) || checkCommentExist.DeleteDate.HasValue)
            {
                throw new Exception("Comment này đã bị vô hiệu hóa");
            }
            var checkRole= await _currentUser.IsInRoleAsync("Admin");
            if (checkRole || _currentUser.UserId != checkCommentExist.UserId)
            {
                throw new UnauthorizedAccessException("Tài khoản hiện tại không có quyền thực hiện chức năng này");
            }
            checkCommentExist.IdUserDelete = _currentUser.UserId;
            checkCommentExist.DeleteDate = DateTime.Now;
            _commentRepository.Update(checkCommentExist);
            var result= await _commentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Xóa thành công");
            }
            else
            {
                return new ResponseResult<string>("Xóa thất bại");
            }
        }
    }
}
