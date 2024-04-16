using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Repositories;

namespace YAHALLO.Application.Commands.ChapterCommand.Update
{
    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, ResponeResult>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IFiles<IFormFile> _files;
        private readonly ICurrentUserService _currentUser;
        public UpdateChapterCommandHandler(IMangaRepository mangaRepository, IChapterRepository chapterRepository, IImageRepository imageRepository, IFiles<IFormFile> files, ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _chapterRepository = chapterRepository;
            _imageRepository = imageRepository;
            _files = files;
            _currentUser = currentUser;
        }

        public async Task<ResponeResult> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            var checkRole = await _currentUser.IsInRoleAsync("1");
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => x.Id == request.MangaId, cancellationToken);
            if (checkMangaExist == null || !string.IsNullOrEmpty(checkMangaExist.IdUserDelete) && checkMangaExist.DeleteDate.HasValue)
            {
                throw new NotFoundException("Không tìm thấy manga hoặc manga đã bị vô hiệu");
            }
            if (checkMangaExist.UserId != _currentUser.UserId || checkRole == false && checkMangaExist.UserId != _currentUser.UserId)
            {
                throw new NotFoundException("Tài khoản hiện tại không có quyền thực hiện chức năng này");
            }
            var checkChapterExist = await _chapterRepository
                .FindAsync(x => x.Id == request.ChapterId && x.MangaId == request.MangaId && x.Index == request.Index
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkChapterExist == null)
            {
                throw new NotFoundException("Không tồn tại chương truyện này");
            }
            var path = $"Data\\Manga\\{checkMangaExist.Id}";
            return new ResponeResult(message: "Đã xảy ra lỗi");
        }
    }
}
