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
        private CommentEntity? _parent;
        private MangaEntity? _manga;
        private ChapterEntity? _chapter;
        public CreateCommentCommandHandler(IUserRepository userRepository, IMangaRepository mangaRepository, ICommentRepository commentRepository,
            IChapterRepository chapterRepository,ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
            _commentRepository = commentRepository;
            _chapterRepository= chapterRepository;
            _currentUser = currentUser; 
            _parent = null;
            _manga = null;  
            _chapter = null;
        }
        public async Task<ResponseResult<string>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        { 
            var checkUserExist= await _userRepository.FindAsync(x=> x.Id==request.UserId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken); 
            if( checkUserExist == null )
            {
                throw new NotFoundException($"Không tồn tại tài khoản với Id {request.UserId}");
            }
            if(request.ParentId != null)
            {
                var checkParentExist= await _commentRepository.FindAsync(x=> x.Id == request.ParentId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken );
                if( checkParentExist != null ) 
                {
                    this._parent = checkParentExist;
                }
            }
            if(request.MangaId != null || request.ChapterId != null )
            {
                if(request.MangaId != null)
                {
                    var checkMangaExist= await _mangaRepository.FindAsync(x=> x.Id == request.MangaId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
                    this._manga = checkMangaExist;
                }
                if(request.ChapterId != null)
                {
                    var checkChapterExist = await _chapterRepository.FindAsync(x => x.Id == request.ChapterId && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
                    this._chapter = checkChapterExist;
                }
            }
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
                Parent = this._parent,
                ParentId = this._parent?.Id ?? null,
                UserEntity = checkUserExist,
                UserId = checkUserExist.Id,
                MangaId = this._manga?.Id,
                MangaEntity = this._manga,
                ChapterEntity = this._chapter,
                ChapterId = this._chapter?.Id,
                CreateDate = DateTime.Now,
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
