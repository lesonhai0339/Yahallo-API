using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.UserEnums;

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
