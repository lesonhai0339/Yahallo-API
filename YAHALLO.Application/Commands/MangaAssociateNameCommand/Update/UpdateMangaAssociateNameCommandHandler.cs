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

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Update
{
    public class UpdateMangaAssociateNameCommandHandler : IRequestHandler<UpdateMangaAssociateNameCommand, bool>
    {
        private readonly IMangaAssociateNameRepository _associateNameRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateMangaAssociateNameCommandHandler(
            IMangaAssociateNameRepository associateNameRepository, ICurrentUserService currentUser)
        {
            _associateNameRepository = associateNameRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateMangaAssociateNameCommand request, CancellationToken cancellationToken)
        {
            var entity = await _associateNameRepository.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (entity is null)
                throw new NotFoundException($"Không tìm thấy tên khác với id {request.Id}");

            entity.Name = request.Name.Trim();
            entity.UpdateDate = DateTime.UtcNow;
            entity.IdUserUpdate = _currentUser.UserId;
            _associateNameRepository.Update(entity);

            var result = await _associateNameRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
