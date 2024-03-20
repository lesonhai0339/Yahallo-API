using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class CommentController : ControllerBase
    {
        private readonly IMediator _sender;
        public CommentController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
