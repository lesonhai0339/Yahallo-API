using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthorCommand.Restore
{
    public class RestoreAuthorCommandHandler : IRequestHandler<RestoreAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreAuthorCommandHandler(IAuthorRepository authorRepository, ICurrentUserService currentUser)
        {
            _authorRepository = authorRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(RestoreAuthorCommand request, CancellationToken cancellationToken)
        {
            var checkAuthorExist = await _authorRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkAuthorExist == null)
            {
                throw new NotFoundException($"Không tồn tại tác giả với Id {request.Id}");
            }
            checkAuthorExist.IdUserDelete = null;
            checkAuthorExist.DeleteDate = null;
            checkAuthorExist.IdUserUpdate = _currentUser.UserId;
            checkAuthorExist.UpdateDate = DateTime.Now;
            _authorRepository.Update(checkAuthorExist);
            var result= await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken); 
            if(result >0)
            {
                return "Phục hòi thành công";
            }
            else
            {
                return "Phục hồi thất bại";
            }
        }
    }
}
