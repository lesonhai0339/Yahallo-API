using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.CommentCommand.Delete
{
    public class DeleteCommentCommand: IRequest<ResponseResult<string>>
    {
        public DeleteCommentCommand(string id)
        {
            Id = id;
        }
        public string Id { get;set; }
    }
}
