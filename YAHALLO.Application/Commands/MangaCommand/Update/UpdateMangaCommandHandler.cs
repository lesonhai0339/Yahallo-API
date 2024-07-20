using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaCommand.Update
{
    public class UpdateMangaCommandHandler : IRequestHandler<UpdateMangaCommand, ResponseResult<string>>
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly IFiles<IFormFile> _files;
        private readonly ICurrentUserService _currentUser;
        private readonly IImageRepository _imageRepository;
        public UpdateMangaCommandHandler(
            IMangaRepository mangaRepository, 
            IFiles<IFormFile> files, 
            ICurrentUserService currentUser,
            IImageRepository imageRepository)
        {
            _mangaRepository = mangaRepository;
            _files = files;
            _currentUser = currentUser;
            _imageRepository = imageRepository; 
        }
        public async Task<ResponseResult<string>> Handle(UpdateMangaCommand request, CancellationToken cancellationToken)
        {
            var checkRole = await _currentUser.IsInRoleAsync("1");
            var checkMangaExist = await _mangaRepository
                .FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if (checkMangaExist == null)
            {
                throw new NotFoundException($"Không tồn tại manga với Id {request.Id}");
            }
            if(checkMangaExist.UserId != _currentUser.UserId || checkRole == false && checkMangaExist.UserId != _currentUser.UserId)
            {
                throw new UnAuthorizeException("Tài khoản hiện tại không có quyền thực hiện chức năng này");
            }
            var checkDuplicateSeason = await _mangaRepository
                .FindAllAsync(x => x.MangaSeasonEntity.Id == checkMangaExist.MangaSeasonEntity.Id && x.Season == request.Season, cancellationToken);
            if(checkDuplicateSeason.Count() > 1)
            {
                throw new DuplicateException("Đã tồn tại season tương tữ cho bộ truyện này");
            }
            checkMangaExist.Name = request.Name ?? checkMangaExist.Name;
            checkMangaExist.Description = request.Description ?? checkMangaExist.Description;
            checkMangaExist.Level = request.Level ?? checkMangaExist.Level;
            checkMangaExist.Status = request.Status ?? checkMangaExist.Status;
            checkMangaExist.Type = request.Type ?? checkMangaExist.Type;
            checkMangaExist.Countries = request.Countries ?? checkMangaExist.Countries;
            checkMangaExist.Season = request.Season ?? checkMangaExist.Season;
            checkMangaExist.UpdateDate = DateTime.Now;
            checkMangaExist.IdUserUpdate = _currentUser.UserId;
            _mangaRepository.Update(checkMangaExist);
            var result= await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                if(request.Thumbnail != null)
                {
                    var mangaThumbnail = await _imageRepository
                        .FindAsync(x => x.UserId == checkMangaExist.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
                    var path = $"Data\\Thumbnail";
                    if (mangaThumbnail != null)
                    {
                        var newImagePath= $"{path}\\{request.Thumbnail.FileName}";
                        mangaThumbnail.BaseUrl = newImagePath;
                        mangaThumbnail.UpdateDate = DateTime.Now;
                        mangaThumbnail.IdUserUpdate= _currentUser.UserId;
                        _imageRepository.Update(mangaThumbnail);
                        var resultsecond = await _imageRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                        if(resultsecond > 0)
                        {
                            _files.DeleteImage(mangaThumbnail.BaseUrl);
                            var check= await _files.UpLoadimage(request.Thumbnail, newImagePath);
                            if(check == true)
                            {
                                return new ResponseResult<string>(message: "Cập nhật thành công");
                            }
                            else
                            {
                                return new ResponseResult<string>(message: "Cập nhật thất bại");
                            }
                        }
                        else
                        {
                            return new ResponseResult<string>(message: "Đã xảy ra lỗi");
                        }
                    }
                }
                return new ResponseResult<string>(message: "Cập nhật thành công");
            }
            else
            {
                return new ResponseResult<string>(message: "Cập nhật thất bại");
            }
        }
    }
}
