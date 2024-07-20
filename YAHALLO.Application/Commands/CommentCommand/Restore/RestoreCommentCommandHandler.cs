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

namespace YAHALLO.Application.Commands.CommentCommand.Restore
{
    public class RestoreCommentCommandHandler : IRequestHandler<RestoreCommentCommand, ResponseResult<string>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreCommentCommandHandler(ICommentRepository commentRepository, ICurrentUserService currentUser)
        {
            _commentRepository = commentRepository;
            _currentUser = currentUser;
        }
        public async Task<ResponseResult<string>> Handle(RestoreCommentCommand request, CancellationToken cancellationToken)
        {
            var checkCommentExist = await _commentRepository.FindAsync(x => x.Id.Equals(request.Id), cancellationToken);
            if( checkCommentExist == null) 
            {
                throw new NotFoundException("Không tìm thấy comment với Id này");
            }
            if(string.IsNullOrEmpty(checkCommentExist.IdUserDelete) || !checkCommentExist.DeleteDate.HasValue)
            {
                throw new NotFoundException("Comment này không bị xóa");
            }
            checkCommentExist.IdUserDelete = null;
            checkCommentExist.DeleteDate = null;
            checkCommentExist.IdUserUpdate = _currentUser.UserId;
            checkCommentExist.UpdateDate = DateTime.Now;
            _commentRepository.Update(checkCommentExist);
            var result= await _commentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);    
            if(result > 0)
            {
                return new ResponseResult<string>("Phục hồi thành công");
            }
            else
            {
                return new ResponseResult<string>("Phục hồi thất bại");
            }
        }
    }
}
