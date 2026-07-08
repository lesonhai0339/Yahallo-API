using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.MangaDaily;
using YAHALLO.Application.Commands.UserCommand.DailyActivity;
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
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, string>
    {
        private readonly IMediator _sender;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateCommentCommandHandler(
            IMediator sender,
            IUserRepository userRepository, 
            ICommentRepository commentRepository,
            ICurrentUserService currentUser
            )
        {
            _sender = sender;   
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _currentUser = currentUser; 
        }
        public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
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
                UserId = _currentUser.UserId,
                MangaId = request.MangaId,
                ChapterId = request.ChapterId,
                CommentToUserId = request.CommentToUserId,  
                ReplyToCommentId = request.ReplyCommentId,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = _currentUser.UserId
            };
            await _sender.Publish(new UpdateMangaDailyNotification { MangaId = request.MangaId, Type = Domain.Enums.MangaDaily.MangaDailyType.Comment }, cancellationToken);
            await _sender.Publish(new UpdateDailyActivityNotification { UserId = _currentUser.UserId!, Type = Domain.Enums.UserDaily.UserDailyType.Comment }, cancellationToken);

            _commentRepository.Add(comment);
            var result = await _commentRepository.UnitOfWork.SaveChangesDroppingDuplicateAnalyticsAsync(cancellationToken);
            if (result == 0)
                throw new Exception("Save comment failed");

            return comment.Id;
        }
    }
}
