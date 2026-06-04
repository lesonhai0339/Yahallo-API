using MediatR;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommand : IRequest<ResponseResult<string>>
    {
        public string UserId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }
        public string? ParentId { get;set; }
        public CommentType Type { get; set; }
        public string Message { get; set; }     
        public CreateCommentCommand(string userid, string? mangaid,string? chapterid,string? parentid, CommentType type, string message)
        {
            UserId = userid;
            MangaId = mangaid;
            ChapterId = chapterid;
            ParentId = parentid;
            Type = type;
            Message = message;
        }
    }
}
