using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class MangaseasonController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaseasonController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
