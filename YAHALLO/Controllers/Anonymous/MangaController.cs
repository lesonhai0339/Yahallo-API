using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class MangaController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
