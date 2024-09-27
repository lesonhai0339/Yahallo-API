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

namespace YAHALLO.Application.Commands.BlogCommand.Restore
{
    public class RestoreBlogCommandHandler : IRequestHandler<RestoreBlogCommand, ResponseResult<string>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreBlogCommandHandler(IBlogRepository blogRepository, ICurrentUserService currentUser)
        {
            _blogRepository = blogRepository;   
            _currentUser = currentUser; 
        }
        public async Task<ResponseResult<string>> Handle(RestoreBlogCommand request, CancellationToken cancellationToken)
        {
            var checkBlogExist = await _blogRepository.FindAsync(x => x.Id.Equals(request.BlogId) && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (checkBlogExist == null) 
            {
                throw new NotFoundException($"Cannot found Blog with Id {request.BlogId}");
            }
            if(checkBlogExist.IdUserCreate != _currentUser.UserId ||! await _currentUser.IsInRoleAsync("Admin"))
            {
                throw new UnAuthorizeException($"You don't have permission to using this method");
            }
            checkBlogExist.IdUserDelete = null;
            checkBlogExist.DeleteDate = null;
            checkBlogExist.IdUserUpdate = _currentUser.UserId;
            checkBlogExist.UpdateDate = DateTime.Now;
            _blogRepository.Update(checkBlogExist);
            var result = await _blogRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result >0 )
            {
                return new ResponseResult<string>("Restore successfully");
            }
            else
            {
                return new ResponseResult<string>("Restore failed");
            }
            throw new NotImplementedException();
        }
    }
}
