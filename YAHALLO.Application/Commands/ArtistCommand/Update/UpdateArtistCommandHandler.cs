using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ArtistCommand.Update
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, string>
    {
        private IArtistRepository _artistRepository;
        private ICurrentUserService _currentUser;
        public UpdateArtistCommandHandler(IArtistRepository artistRepository, ICurrentUserService currentUser)
        {
            _artistRepository = artistRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var checkArtistExists = await _artistRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkArtistExists == null)
            {
                throw new NotFoundException($"Không tồn tại họa sĩ với Id {request.Id}");
            }
            checkArtistExists.Name = request.Name ?? checkArtistExists.Name;
            checkArtistExists.Countries = request.Countries != null ? (CountriesEnum)request.Countries: checkArtistExists.Countries;
            checkArtistExists.Depscription = request.Depscription ?? checkArtistExists.Depscription;
            checkArtistExists.Birth = request.Birth ?? checkArtistExists.Birth;
            checkArtistExists.LifeStatus = request.LifeStatus != null ? (LifeStatus)request.LifeStatus : checkArtistExists.LifeStatus;
            checkArtistExists.IdUserUpdate = _currentUser.UserId;
            checkArtistExists.UpdateDate = DateTime.Now;
            _artistRepository.Update(checkArtistExists);
            var result = await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result>0)
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
