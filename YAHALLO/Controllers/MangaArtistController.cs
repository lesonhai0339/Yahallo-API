using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class MangaArtistController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaArtistController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
