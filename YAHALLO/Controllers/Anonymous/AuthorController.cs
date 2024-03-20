using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _sender;
        public AuthorController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
