using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using NotMappedAttribute = YAHALLO.Domain.Exceptions.NotMappedAttribute;

namespace YAHALLO.Application.Commands.ChapterCommand.Create
{
    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, ResponseResult<string>>
    {
        private IChapterRepository _chapterRepository;
        private IMangaRepository _mangaRepository;
        private ICurrentUserService _currentUser;
        private readonly IFiles<IFormFile> _files;
        private readonly IStorageService<ChapterImage> _chapterStorageService;
        public CreateChapterCommandHandler(IChapterRepository chapterRepository, IMangaRepository mangaRepository, ICurrentUserService currentUser,
            IStorageService<ChapterImage> chapterStorageService
            , IFiles<IFormFile> files)
        {
            _chapterRepository = chapterRepository;
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
            _files = files;
            _chapterRepository = chapterRepository; 
        }

        public async Task<ResponseResult<string>> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            var hasAccess = await _currentUser.IsInRoleAsync("1");

            //Manga
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => x.Id == request.MangaId
                    && string.IsNullOrEmpty(x.IdUserDelete)
                    && !x.DeleteDate.HasValue, cancellationToken);

            if(checkMangaExist == null)
                throw new NotFoundException("Không tìm thấy manga hoặc manga đã bị vô hiệu");


            if (checkMangaExist.UserId != _currentUser.UserId || !hasAccess)
                throw new ForbiddenAccessException("Tài khoản hiện tại không có quyền thực hiện chức năng này");

            //Chapter
            var checkChapterExist = await _chapterRepository
                .FindAllAsync(x => 
                x.MangaId == request.MangaId 
                && x.Index == request.Index
                && string.IsNullOrEmpty(x.IdUserDelete) 
                && !x.DeleteDate.HasValue, cancellationToken);

            if(checkChapterExist.Any())
                throw new DuplicateException("Đã tồn tại chapter với index cho manga tương tự");

            var chapter = new ChapterEntity
            {
                Title = request.Title,
                Index = request.Index,
                MangaId = request.MangaId,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,

            };
            _chapterRepository.Add(chapter);

            //Update last chapter for manga
            checkMangaExist.LastChapterId = chapter.Id;
            checkMangaExist.LastChapterIndex = chapter.Index;
            checkMangaExist.LastChapterUpdate = chapter.CreateDate;

            var chapterState = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (chapterState == 0)
                throw new Exception("Tạo chapter thất bại");

            return new ResponseResult<string>(message: chapter.Id);
        }
    }
}
