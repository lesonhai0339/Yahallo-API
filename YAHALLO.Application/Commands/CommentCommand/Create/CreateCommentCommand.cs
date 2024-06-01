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
    public class CreateCommentCommand: IRequest<ResponseResult<string>>
    {
        public string UserId { get;set; }
        public string MangaId { get;set; }
        public MangaCommentType Type { get;set; }
        public string Data { get;set; } 
        public CreateCommentCommand(string userid, string mangaid, MangaCommentType type, string data)
        {
            UserId = userid;
            MangaId = mangaid;
            Type = type;
            Data = data;
        }
    }
}
