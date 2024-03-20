using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _sender;
        public UserRoleController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
