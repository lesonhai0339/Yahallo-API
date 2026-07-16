using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Commands.Mention.Create
{
    public class CreateMentionNotification: INotification
    {
        public string? UserId { get; init; } 
        public string? RootCommentId { get; init; } 

        public string? CommentId { get; init; } 
        public MentionFrom MentionFrom { get; init; }
        public string? MangaId { get; init; }
        public string? ChapterId { get; init; }
        public string? BlogId { get; init; }
    }
}
