using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Repositories;

namespace YAHALLO.Application.Commands.ChapterCommand.Update
{
    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, ResponeResult<string>>
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

        public async Task<ResponeResult<string>> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
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
                .FindAsync(x => x.Id == request.ChapterId && x.MangaId == request.MangaId
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkChapterExist == null)
            {
                throw new NotFoundException("Không tồn tại chương truyện này");
            }
            var path = $"Data\\Manga\\{checkMangaExist.Id}";
            checkChapterExist.Title = request.Title ?? checkChapterExist.Title;
            var checkExistIndex =await _chapterRepository
                .FindAsync(x => x.Id != request.ChapterId 
                && x.MangaId == request.MangaId 
                && x.Index == request.Index 
                && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkExistIndex != null)
            {
                throw new DuplicateException($"Đã tồn tại chương truyện có vị trí tương tự");
            }
            checkChapterExist.Index = request.Index ?? checkChapterExist.Index;
            checkChapterExist.UpdateDate = DateTime.Now;
            checkChapterExist.IdUserUpdate = _currentUser.UserId;
            _chapterRepository.Update(checkChapterExist);
            var result=await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
               if(request.Images != null || request.ImageUrls != null)
                {
                    var listimages =await _imageRepository.FindAllAsync(x =>x.ChapterId == request.ChapterId && x.TypeImage == TypeImage.Chapter, cancellationToken);
                    if (listimages != null)
                    {
                        foreach(var image in listimages) 
                        { 
                            if(image == null)
                            {
                                continue;
                            }
                            if(request.Images != null && request.ImageUrls!= null)
                            {
                                if(request.ImageUrls.Count != request.Images.Count)
                                {
                                    throw new Exception($"Số lượng ảnh và url khác nhau");
                                }
                                for(int i=0;i<request.Images.Count;i++)
                                {
                                    if (image.BaseUrl.Contains(request.Images[i].FileName))
                                    {
                                        string oldUrl = new string(image.BaseUrl);
                                        image.BaseUrl = $"{path}\\{request.Images[i].FileName}";
                                        image.CloudUrl = request.ImageUrls.FirstOrDefault(x => image.CloudUrl!.Contains(x));
                                        _imageRepository.Update(image);
                                        _files.DeleteImage(oldUrl);
                                        await _files.UpLoadimage(request.Images[i], $"{path}");
                                    }
                                }
                            }
                            else if (request.Images != null && request.ImageUrls == null)
                            {
                                for (int i = 0; i < request.Images.Count; i++)
                                {
                                    if (image.BaseUrl.Contains(request.Images[i].FileName))
                                    {
                                        string oldUrl = new string(image.BaseUrl);
                                        image.BaseUrl = $"{path}\\{request.Images[i].FileName}";
                                        _imageRepository.Update(image);
                                        _files.DeleteImage(oldUrl);
                                        await _files.UpLoadimage(request.Images[i], $"{path}");
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < request.ImageUrls!.Count; i++)
                                {
                                    if (image.BaseUrl.Contains(request.ImageUrls[i]))
                                    {
                                        image.BaseUrl = request.ImageUrls[i];
                                        image.CloudUrl = request.ImageUrls[i];
                                        _imageRepository.Update(image);
                                    }
                                }
                            }
                        }
                        try
                        {
                            var imageResult = await _imageRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                            if(result > 0)
                            {
                                return new ResponeResult<string>(message: "Cập nhật thành công");
                            }
                            else
                            {
                                return new ResponeResult<string>(message: "Cập nhật thất bại");
                            }
                        }
                        catch(SqlException ex)
                        {
                            throw new Exception($"Đã xảy ra lỗi tronng quá trình cập nhật dữ liệu: {ex}");
                        }
                    }
                }
                return new ResponeResult<string>(message: "Cập nhật thành công");
            }
            return new ResponeResult<string>(message: "Đã xảy ra lỗi");
        }
    }
}
