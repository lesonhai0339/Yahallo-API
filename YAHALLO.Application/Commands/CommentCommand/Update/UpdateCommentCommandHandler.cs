using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.CommentCommand.Update
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, ResponseResult<string>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IFiles<IFormFile> _files;
        private readonly ICurrentUserService _currentUser;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, ICurrentUserService currentUser, IFiles< IFormFile> files)
        {
            _commentRepository = commentRepository;
            _files = files;
            _currentUser = currentUser;
        }
        public async Task<ResponseResult<string>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var checkCommentExst = await _commentRepository.FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkCommentExst == null)
            {
                throw new NotFoundException($"Không tìm thấy bình luận với Id {request.Id}");
            }
            var checkRole = await _currentUser.IsInRoleAsync("Admin");
            if (checkCommentExst.UserId != _currentUser.UserId || !checkRole)
            {
                throw new UnauthorizedAccessException("Tài khoản hiện tại không thể thực hiện chức năng này");
            }
            if(request.MediaFile != null && checkCommentExst.MetaData != null)
            {
                string old_file = checkCommentExst.MetaData.Url1!;
                if(File.Exists(old_file)) 
                {
                    try
                    {
                        bool check = _files.DeleteImage(old_file);
                        if (!check)
                        {
                            throw new IOException("Thất bại trong quá trình cập nhật dữ liệu");
                        }
                        string? parent_folder = checkCommentExst.MangaId ?? checkCommentExst.ChapterId;
                        var path = $"Data\\Comments\\{parent_folder}";
                        bool upFile = await _files.UpLoadimage(request.MediaFile, Path.Combine(path, request.MediaFile.FileName));
                        if (!upFile) 
                        {
                            throw new IOException("Thất bại trong quá trình cập nhật dữ liệu");
                        }
                        checkCommentExst.MetaData.Url1 = Path.Combine(path, request.MediaFile.FileName);
                    }
                    catch(IOException e)
                    {
                        throw new IOException("Thất bại trong quá trình cập nhật: ",e);
                    }

                }
            }
            checkCommentExst.UpdateDate = DateTime.Now;
            checkCommentExst.IdUserUpdate = _currentUser.UserId;
            checkCommentExst.Message = request.Message ?? checkCommentExst.Message;
            checkCommentExst.CanComment = request.CanComment ?? checkCommentExst.CanComment;
            checkCommentExst.CanHide = request.CanHide ?? checkCommentExst.CanHide;
            checkCommentExst.CanReply = request.CanReply ?? checkCommentExst.CanReply;
            checkCommentExst.CanLike = request.CanLike ??  checkCommentExst.CanLike;
            checkCommentExst.CanRemove = request.CanRemove ?? checkCommentExst.CanRemove;
            _commentRepository.Update(checkCommentExst);
            var result=await _commentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if( result > 0)
            {
                return new ResponseResult<string>("Cập nhật thành công");
            }
            else
            {
                return new ResponseResult<string>("Cập nhật thất bại");
            }
        }
    }
}
