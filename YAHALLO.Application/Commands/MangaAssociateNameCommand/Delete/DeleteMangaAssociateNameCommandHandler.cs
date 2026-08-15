//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Delete
{
    public class DeleteMangaAssociateNameCommandHandler : IRequestHandler<DeleteMangaAssociateNameCommand, bool>
    {
        private readonly IMangaAssociateNameRepository _associateNameRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteMangaAssociateNameCommandHandler(
            IMangaAssociateNameRepository associateNameRepository, ICurrentUserService currentUser)
        {
            _associateNameRepository = associateNameRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeleteMangaAssociateNameCommand request, CancellationToken cancellationToken)
        {
            var entity = await _associateNameRepository.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (entity is null)
                throw new NotFoundException($"Không tìm thấy tên khác với id {request.Id}");

            entity.DeleteDate = DateTime.UtcNow;
            entity.IdUserDelete = _currentUser.UserId;
            _associateNameRepository.Update(entity);

            var result = await _associateNameRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
