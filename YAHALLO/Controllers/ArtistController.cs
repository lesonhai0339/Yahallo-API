using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _sender;
        public ArtistController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
