using MediatR;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.BlogCommand.Delete
{
    public class DeleteBlogCommand: IRequest<ResponseResult<string>>
    {
        public string BlogId { get; set; }
        public DeleteBlogCommand(string blogId)
        {
            BlogId = blogId;
        }   
    }
}
