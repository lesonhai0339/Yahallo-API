using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class MangaAssociatenameController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaAssociatenameController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
