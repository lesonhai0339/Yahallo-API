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

namespace YAHALLO.Application.Commands.MangaCommand.Restore
{
    public class RestoreMangaCommandHandler : IRequestHandler<RestoreMangaCommand, ResponeResult>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreMangaCommandHandler(IMangaRepository mangaRepository, ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
        }
    
        public async Task<ResponeResult> Handle(RestoreMangaCommand request, CancellationToken cancellationToken)
        {
            var checkRole =await _currentUser.IsInRoleAsync("1");
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkMangaExist == null)
            {
                throw new NotFoundException($"Không tìm thấy manga nào có Id {request.Id} bị xóa");
            }
            if(checkMangaExist.UserId != _currentUser.UserId || checkRole == false)
            {
                throw new UnAuthorizeException("Tài khoản hiện tại không có quyền sử dụng chức năng này");
            }
            checkMangaExist.IdUserDelete = null;
            checkMangaExist.DeleteDate = null;
            checkMangaExist.UpdateDate = DateTime.Now;
            checkMangaExist.IdUserUpdate = _currentUser.UserId;
            _mangaRepository.Update(checkMangaExist);
            var result = await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponeResult(message: "Phục hồi thành công");
            }
            else
            {
                return new ResponeResult(message: "Phục hồi thất bại");
            }
        }
    }
}
