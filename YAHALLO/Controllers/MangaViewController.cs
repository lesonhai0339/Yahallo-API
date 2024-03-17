using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class MangaViewController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaViewController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
