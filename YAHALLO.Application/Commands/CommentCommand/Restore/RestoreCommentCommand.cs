using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.CommentCommand.Restore
{
    public class RestoreCommentCommand: IRequest<ResponseResult<string>>
    {
        public string Id { get; set; }
        public RestoreCommentCommand(string id)
        {
            Id = id;
        }
    }
}
