using MediatR;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommand : IRequest<ResponseResult<string>>
    {
        public string UserId { get; set; } = string.Empty;
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? ParentId { get;set; }
        public string? ReplyCommentId { get; set; } 
        public string? CommentToUserId { get; set; }    
        public CommentType Type { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
