using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class FollowController : ControllerBase
    {
        private readonly IMediator _sender;
        public FollowController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
