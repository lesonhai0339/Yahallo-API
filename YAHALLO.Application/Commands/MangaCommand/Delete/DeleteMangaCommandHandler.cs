using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaCommand.Delete
{
    public class DeleteMangaCommandHandler : IRequestHandler<DeleteMangaCommand, ResponseResult<string>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        public DeleteMangaCommandHandler(IMangaRepository mangaRepository, ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
        }

        public async Task<ResponseResult<string>> Handle(DeleteMangaCommand request, CancellationToken cancellationToken)
        {
            var checkUserForManga= await _mangaRepository
                .FindAsync(x=> x.Id == request.Id&& string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkUserForManga == null)
            {
                throw new NotFoundException($"Không tìm thấy manga với Id {request.Id}");
            }
            // Quyền truy cập đã được kiểm soát qua [Authorize(Roles="Admin,Mod")] trên command.
            checkUserForManga.DeleteDate = DateTime.UtcNow;
            checkUserForManga.IdUserDelete = _currentUser.UserId;
            _mangaRepository.Update(checkUserForManga);
            var result = await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>(message: "Xóa thành công");
            }
            else
            {
                return new ResponseResult<string>(message: "Xóa thất bại");
            }
        }
    }
}
