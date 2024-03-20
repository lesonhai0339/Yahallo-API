using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
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
