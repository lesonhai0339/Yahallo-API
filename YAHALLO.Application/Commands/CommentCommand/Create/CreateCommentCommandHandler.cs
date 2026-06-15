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

            var commentUser= await _userRepository.FindAsync(x=> x.Id == request.UserId, cancellationToken); 
            if( commentUser == null )
                throw new NotFoundException($"Không tồn tại tài khoản với Id {request.UserId}");

            var userReplyTo = !string.IsNullOrEmpty(request.CommentToUserId)
                ? await _userRepository.FindAsync(x => x.Id == request.CommentToUserId, cancellationToken):
                null;   

            var commentRoot = !string.IsNullOrEmpty(request.ParentId) 
                ? await _commentRepository.FindAsync(x => x.Id == request.ParentId, cancellationToken) 
                : null;

            var manga = !string.IsNullOrEmpty(request.MangaId)
                ? await _mangaRepository.FindAsync(x => x.Id == request.MangaId, cancellationToken)
                : null;

            var chapter = !string.IsNullOrEmpty(request.ChapterId)
               ? await _chapterRepository.FindAsync(x => x.Id == request.ChapterId, cancellationToken)
               : null;

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
                Parent = commentRoot,
                ParentId = commentRoot?.Id,
                UserEntity = commentUser,
                UserId = commentUser.Id,
                MangaId = manga?.Id,
                MangaEntity = manga,
                ChapterId = chapter?.Id,
                ChapterEntity = chapter,
                CommentToUserId = commentUser?.Id,  
                CommentToUser = commentUser,        
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
