using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class MangaAuthorController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaAuthorController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
