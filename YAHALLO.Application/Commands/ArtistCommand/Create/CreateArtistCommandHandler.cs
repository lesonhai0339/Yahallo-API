using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ArtistCommand.Create
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, string>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICurrentUserService _currentUserRepository;
        public CreateArtistCommandHandler(
            IArtistRepository artistRepository,
            ICurrentUserService currentUserRepository)
        {
            _artistRepository = artistRepository;
            _currentUserRepository = currentUserRepository;
        }
        public async Task<string> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var checkArtistByName= await _artistRepository
                .FindAsync(x=> EF.Functions.Like(x.Name, request.Name) && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkArtistByName != null)
            {
                throw new NotFoundException($"Đã tồn tại tác giả với tên {request.Name}");
            }
            var newArtist = new ArtistEntity
            {
                Name = request.Name,
                Depscription = request.Depscription,
                Countries = (CountriesEnum)request.CountryCode,
                Birth = request.Birth,
                LifeStatus =(LifeStatus)request.LifeStatus,
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUserRepository.UserId
            };
            _artistRepository.Add(newArtist);
            var result = await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return "Tạo thành công";
            }
            else
            {
                return "Tạo thất bại";
            }
        }
    }
}
