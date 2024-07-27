using MediatR;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.AttechmentCommand.Create
{
    public class CreateAttechmentCommand: IRequest<ResponseResult<string>>
    {
        public CreateAttechmentCommand(string? blogid, string? commentid,bool isHaveMedia, string? description, CommentMediaType? mediaType, IFormFile? mediaFile, string? title, string? url1, string? url2, string? url3)
        {
            BlogId = blogid;
            CommentId = commentid;
            IsHaveMedia = isHaveMedia;
            Description = description;
            MediaType = mediaType;
            MediaFile = mediaFile;
            Title = title;
            Url1 = url1;
            Url2 = url2;
            Url3 = url3;
        }
        public string? BlogId { get; set; }
        public string? CommentId { get;set; }
        public bool IsHaveMedia { get; set; }
        public string? Description { get; set; }
        public CommentMediaType? MediaType { get; set; }
        public IFormFile? MediaFile { get; set; }
        public string? Title { get; set; }
        public string? Url1 { get; set; }
        public string? Url2 { get; set; }
        public string? Url3 { get; set; }
    }
}
