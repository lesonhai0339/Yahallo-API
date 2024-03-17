
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class UserTokenController : ControllerBase
    {
        private readonly IMediator _sender;
        public UserTokenController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
