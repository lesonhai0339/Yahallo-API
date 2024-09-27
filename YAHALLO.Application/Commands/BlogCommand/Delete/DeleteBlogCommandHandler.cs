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

namespace YAHALLO.Application.Commands.BlogCommand.Delete
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, ResponseResult<string>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IAttechmentRepository _attechmentRepository;
        private readonly IThreadOfBlogRepository _threadOfBlogRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteBlogCommandHandler(IBlogRepository blogRepository, IAttechmentRepository attechmentRepository, IThreadOfBlogRepository threadOfBlogRepository, IReactionRepository reactionRepository, ICommentRepository commentRepository, ICurrentUserService currentUser)
        {
            _blogRepository = blogRepository;
            _attechmentRepository = attechmentRepository;
            _threadOfBlogRepository = threadOfBlogRepository;
            _reactionRepository = reactionRepository;
            _commentRepository = commentRepository;
            _currentUser = currentUser;
        }
    
        public async Task<ResponseResult<string>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var checkBlogExist = await _blogRepository.FindAsync(x => x.Id.Equals(request.BlogId) && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkBlogExist == null)
            {
                throw new NotFoundException($"Does not exit Blog with Id {request.BlogId}");
            }
            if(_currentUser.UserId != checkBlogExist.IdUserCreate || !await _currentUser.IsInRoleAsync("Admin"))
            {
                throw new UnAuthorizeException("Current User not blog owner or doesn't have Admin role");
            }
            checkBlogExist.Attechments?.Select(x => { x.IdUserDelete = _currentUser.UserId; x.DeleteDate = DateTime.Now; return x; }).ToList();
            checkBlogExist.ThreadOfBlogEntities?.Select(x => { x.IdUserDelete = _currentUser.UserId; x.DeleteDate = DateTime.Now; return x; }).ToList();
            checkBlogExist.Comments?.Select(x => { x.IdUserDelete = _currentUser.UserId; x.DeleteDate = DateTime.Now; return x; }).ToList();
            checkBlogExist.Reactions?.Select(x => { x.IdUserDelete = _currentUser.UserId; x.DeleteDate = DateTime.Now; return x; }).ToList();
            checkBlogExist.DeleteDate = DateTime.Now;
            checkBlogExist.IdUserDelete = _currentUser.UserId;
            _blogRepository.Update(checkBlogExist);
            var result = await _blogRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Delete successfully");
            }
            else
            {
                return new ResponseResult<string>("Delete failed");
            }
        }
    }
}
