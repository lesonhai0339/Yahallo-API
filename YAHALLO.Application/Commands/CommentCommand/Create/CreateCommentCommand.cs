using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MangaCommentType Type { get; set; }
        public string Message { get; set; }
        //CommentAttechment
        public bool IsHaveMedia { get; set; }   
        public string? Description { get; set; }
        public string? MediaType { get; set; }
        public string? Title { get; set; }
        public string? Url1 { get; set; }
        public string? Url2 { get; set; }
        public string? Url3 { get; set; }
        public CreateCommentCommand(string userid, string? mangaid,string? chapterid,string? parentid, MangaCommentType type, string message,
            string? description, string? mediatype, string? title, string? url1, string? url2, string? url3)
        {
            UserId = userid;
            MangaId = mangaid;
            ChapterId = chapterid;
            ParentId = parentid;
            Type = type;
            Message = message;
            Description = description;
            MediaType = mediatype;
            Title = title;  
            Url1 = url1;
            Url2 = url2;
            Url3 = url3;
        }
    }
}
