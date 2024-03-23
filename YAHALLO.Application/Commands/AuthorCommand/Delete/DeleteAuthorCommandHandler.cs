using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthorCommand.Delete
{
    public class DeleteAuthorCommandhandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteAuthorCommandhandler(
            IAuthorRepository authorRepository,
            ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
            _authorRepository = authorRepository;
        }
        public async Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var checkAuthorExist= await _authorRepository
                .FindAsync(x=> x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkAuthorExist == null )
            {
                throw new NotFoundException($"Không tìm thấy tác giả nào với Id {request.Id}");
            }
            checkAuthorExist.IdUserDelete = _currentUser.UserId;
            checkAuthorExist.DeleteDate = DateTime.Now;
            _authorRepository.Update(checkAuthorExist);
            var result = await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}
