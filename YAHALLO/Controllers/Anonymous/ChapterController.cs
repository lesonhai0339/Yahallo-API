using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class ChapterController : ControllerBase
    {
        private readonly IMediator _sender;
        public ChapterController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
