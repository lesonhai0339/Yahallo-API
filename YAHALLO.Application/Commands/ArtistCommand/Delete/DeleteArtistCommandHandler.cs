using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ArtistCommand.Delete
{
    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, string>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteArtistCommandHandler(IArtistRepository artistRepository, ICurrentUserService currentUserService)
        {
            _artistRepository = artistRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var checkArtistExists = await _artistRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkArtistExists == null)
            {
                throw new NotFoundException($"Không tìm thấy họa sĩ nào có Id {request.Id}");
            }
            checkArtistExists.IdUserDelete = _currentUserService.UserId;
            checkArtistExists.DeleteDate = DateTime.Now;
            _artistRepository.Update(checkArtistExists);
            var result = await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result>0)
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
