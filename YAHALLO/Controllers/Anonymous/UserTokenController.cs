
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
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
