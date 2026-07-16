using MediatR;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommand : IRequest<string>
    {
        public string? MangaId { get; set; } = null!;
        public string? ChapterId { get; set; }
        public string? BlogId { get; set; } 
        public string? ReplyCommentId { get; set; } 
        public CommentType Type { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
