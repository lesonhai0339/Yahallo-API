using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.MangaDaily;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.Mention.Create
{
    public class CreateMentionNotificationHandler : INotificationHandler<CreateMentionNotification>
    {
        private readonly ILogger<CreateMentionNotificationHandler> _logger;

        private readonly IMentionRepository _mentionRepository;
        public CreateMentionNotificationHandler(ILogger<CreateMentionNotificationHandler> logger, IMentionRepository mentionRepository)   
        {
            _logger = logger;       
            _mentionRepository = mentionRepository;
        }

        public async Task Handle(CreateMentionNotification request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.RootCommentId))
                return;

            var mention = new MentionEntity
            {
                UserId = request.UserId,
                RootCommentId = request.RootCommentId,
                CommentId = request.CommentId,
                Seen = false,
                MentionFrom = request.MentionFrom,
                MangaId = request.MangaId,
                ChapterId = request.ChapterId,
                BlogId = request.BlogId
            };
            _mentionRepository.Add(mention);
        }
    }
}
