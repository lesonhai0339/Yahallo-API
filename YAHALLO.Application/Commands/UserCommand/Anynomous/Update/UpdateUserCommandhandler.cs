
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Update
{
    public class UpdateUserCommandhandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IFiles<IFormFile> _files;
        public UpdateUserCommandhandler(
            IUserRepository userRepository,
            IImageRepository imageRepository,
            ICurrentUserService currentUser,
            IFiles<IFormFile> files)
        {
            _userRepository = userRepository;
            _imageRepository = imageRepository;
            _currentUser = currentUser;
            _files = files;
        }
        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var checkUserExists = await _userRepository
                .FindAsync(x => x.Id == request.Id && !x.DeleteDate.HasValue && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (checkUserExists == null)
            {
                throw new NotFoundException($"Không tìm thấy thanh viên với Id {request.Id}");
            }
            var path = $"Data\\User";
            //var path = $"{Directory.GetCurrentDirectory()}\\Data\\User";
            checkUserExists.DisplayName = request.DisplayName ?? checkUserExists.DisplayName;
            checkUserExists.PhoneNumber = request.PhoneNumber ?? checkUserExists.PhoneNumber;
            if (request.Avatar != null)
            {
                var checkImage = await _imageRepository.FindAsync(x => x.UserId == checkUserExists.Id, cancellationToken);
                if (checkImage == null)
                {
                    var userAvatar = new ImageEntity(index: 1, $"{path}\\{request.Avatar.FileName}",null, TypeImage.User, checkUserExists.Id, null, null, _currentUser.UserId, DateTime.Now);
                    _imageRepository.Add(userAvatar);
                    var resultimg = await _imageRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (resultimg > 0)
                    {
                        var upfiles = await _files.UpLoadimage(request.Avatar, path);
                        if (upfiles == true)
                        {
                            return "Thay đổi thông tin thành công";
                        }
                    }
                    throw new NotFoundException("Đã gặp lỗi trong quá trình cập nhật dữ liệu");
                }
                else
                {
                    var deleteOldImage = _files.DeleteImage(checkImage.BaseUrl);
                    if (deleteOldImage == false)
                    {
                        throw new Exception("Xảy ra lỗi trong quá trình cập nhật dữ liệu");
                    }
                    checkImage.BaseUrl = $"{path}\\{request.Avatar.FileName}";
                    checkImage.UpdateDate = DateTime.Now;
                    checkImage.IdUserUpdate = _currentUser.UserId;
                    _imageRepository.Update(checkImage);
                    var resultimg = await _imageRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    if (resultimg > 0)
                    {
                        var upfiles = _files.UpLoadimage(request.Avatar, path);
                        if (upfiles.IsCompleted)
                        {
                            return "Thay đổi thông tin thành công";
                        }
                    }
                    throw new NotFoundException("Đã gặp lỗi trong quá trình cập nhật dữ liệu");
                }
            }
            _userRepository.Update(checkUserExists);
            var result = await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Cập nhật thành công";
            }
            else
            {
                return "Đã xảy ra lỗi trong quá trình cập nhật";
            }
        }
    }
}
