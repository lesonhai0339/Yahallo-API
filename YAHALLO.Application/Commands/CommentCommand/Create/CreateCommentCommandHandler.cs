using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ResponseResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateCommentCommandHandler(IUserRepository userRepository, IMangaRepository mangaRepository, ICommentRepository commentRepository,
            IChapterRepository chapterRepository,ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
            _commentRepository = commentRepository;
            _chapterRepository= chapterRepository;
            _currentUser = currentUser; 
        }
        public async Task<ResponseResult<string>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(request.UserId);
            bool hasManga = !string.IsNullOrEmpty(request.MangaId);

            // MangaId luôn bắt buộc. ChapterId tùy chọn:
            //  - chỉ MangaId      => comment cho manga
            //  - MangaId+ChapterId => comment cho chapter (chapter luôn thuộc 1 manga)
            if (!hasManga)
                throw new BadRequestException("Comment phải thuộc về một manga");

            var commentUser = await _userRepository.FindAsync(x=> x.Id == request.UserId, cancellationToken); 
            if( commentUser == null )
                throw new NotFoundException($"Không tồn tại tài khoản với Id {request.UserId}");

            CommentEntity comment = new CommentEntity
            {
                CanComment = true,
                CanRemove = true,
                CanHide = true,
                CanLike = true,
                CanReply = true,
                CommentCount = 0,
                LikeCount = 0,
                DisLikeCount = 0,
                Message = request.Message,
                ParentId = request.ParentId,
                UserId = commentUser.Id,
                MangaId = request.MangaId,
                ChapterId = request.ChapterId,
                CommentToUserId = request.CommentToUserId,  
                ReplyToCommentId = request.ReplyCommentId,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = _currentUser.UserId
            };
            _commentRepository.Add(comment);
            int result = await _commentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return new ResponseResult<string>(comment.Id);
            }
            else
            {
                return new ResponseResult<string>(comment.Id);
            }
            //if paramenter parentid not null the parent comment entity need to update commentCount. this comment is considers as a reply comment
            //neu tham so parentid khong rong thi ta can phai cap nhat commentCount cho parent comment vi binh luan nay la mot binh luan tra loi cho binh luan parent
        }
    }
}
