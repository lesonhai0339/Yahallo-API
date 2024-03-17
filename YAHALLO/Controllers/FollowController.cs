using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
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
