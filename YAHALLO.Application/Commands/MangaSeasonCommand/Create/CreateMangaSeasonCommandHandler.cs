using MediatR;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Create
{
    public class CreateMangaSeasonCommandHandler : IRequestHandler<CreateMangaSeasonCommand, ResponseResult<string>>
    {
        private readonly IMangaSeasonRepository _mangaSeasonRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateMangaSeasonCommandHandler(IMangaSeasonRepository mangaSeasonRepository, ICurrentUserService currentUser)
        {
            _mangaSeasonRepository = mangaSeasonRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(CreateMangaSeasonCommand request, CancellationToken cancellationToken)
        {
            MangaSeasonEntity entity = new MangaSeasonEntity
            {
                Season = request.Season,
                Description = request.Description,
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUser.UserId,
            };
            _mangaSeasonRepository.Add(entity); 
            var result= await _mangaSeasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseResult<string>("Tạo thành công");
            }
            else
            {
                return new ResponseResult<string>("Tạo thất bại");
            }
        }
    }
}
