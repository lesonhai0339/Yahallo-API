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
        public MangaCommentType Type { get; set; }
        public string Message { get; set; }
        //CommentAttechment
        public bool IsHaveMedia { get; set; }   
        public string? Description { get; set; }
        public CommentMediaType? MediaType { get; set; }
        public IFormFile? MediaFile { get; set; }
        public string? Title { get; set; }
        public string? Url1 { get; set; }
        public string? Url2 { get; set; }
        public string? Url3 { get; set; }
        public CreateCommentCommand() { }
        public CreateCommentCommand(string userid, string? mangaid,string? chapterid,string? parentid, MangaCommentType type, string message,
            string? description, CommentMediaType? mediatype, string? title, string? url1, string? url2, string? url3)
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
