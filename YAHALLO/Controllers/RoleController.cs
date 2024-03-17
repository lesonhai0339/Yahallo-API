using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class RoleController : ControllerBase
    {
        private readonly IMediator _sender;
        public RoleController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
