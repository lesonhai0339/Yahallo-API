using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ArtistCommand.Restore
{
    public class RestoreArtistCommandHandler : IRequestHandler<RestoreArtistCommand, string>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreArtistCommandHandler(IArtistRepository artistRepository, ICurrentUserService currentUser)
        {
            _artistRepository = artistRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(RestoreArtistCommand request, CancellationToken cancellationToken)
        {
            var checkArtistExists = await _artistRepository
                .FindAsync(x => x.Id == request.Id && !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkArtistExists == null)
            {
                throw new NotFoundException($"Không tìm thấy tác giả với Id {request.Id}");
            }
            checkArtistExists.IdUserDelete = null;
            checkArtistExists.DeleteDate = null;
            checkArtistExists.UpdateDate = DateTime.Now;
            checkArtistExists.IdUserUpdate = _currentUser.UserId;
            _artistRepository.Update(checkArtistExists);
            var result = await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return "Phục hồi thành công";
            }
            else
            {
                return "Phục hồi thất bại";
            }
        }
    }
}
