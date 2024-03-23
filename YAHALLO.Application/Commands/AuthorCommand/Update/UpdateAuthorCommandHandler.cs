using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthorCommand.Update
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, ICurrentUserService currentUser)
        {
            _authorRepository = authorRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var checkAuthorExist = await _authorRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkAuthorExist == null)
            {
                throw new NotFoundException($"Không tìm thấy tác giả nào có Id {request.Id}");
            }
            checkAuthorExist.Name = request.Name ?? checkAuthorExist.Name;
            checkAuthorExist.Countries = request.Countries ?? checkAuthorExist.Countries;
            checkAuthorExist.Depscription = request.Depscription ?? checkAuthorExist.Depscription;
            checkAuthorExist.Birth = request.Birth ?? checkAuthorExist.Birth;
            checkAuthorExist.LifeStatus = request.LifeStatus ?? checkAuthorExist.LifeStatus;
            checkAuthorExist.UpdateDate = DateTime.Now;
            checkAuthorExist.IdUserUpdate = _currentUser.UserId;
            _authorRepository.Update(checkAuthorExist);
            var result = await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return "Cập nhật thành công";
            }
            else
            {
                return "Cập nhật thất bại";
            }
        }
    }
}
