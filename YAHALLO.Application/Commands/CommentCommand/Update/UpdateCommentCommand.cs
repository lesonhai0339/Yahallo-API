using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.CommentCommand.Update
{
    public class UpdateCommentCommand: IRequest<ResponseResult<string>>
    {
        public UpdateCommentCommand(string id, string? message, bool? canComment, bool? canRemove, bool? canHide, bool? canLike, bool? canReply)
        {
            Id = id;
            Message = message;
            CanComment = canComment;
            CanRemove = canRemove;
            CanHide = canHide;
            CanLike = canLike;
            CanReply = canReply;
        }
        public string Id {  get; set; } 
        public string? Message { get; set; }
        public bool? CanComment { get; set; }
        public bool? CanRemove { get; set; }
        public bool? CanHide { get; set; }
        public bool? CanLike { get; set; }
        public bool? CanReply { get; set; }
    }
}
