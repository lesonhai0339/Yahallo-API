using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class MangaRatingController : ControllerBase
    {
        private readonly IMediator _sender;
        public MangaRatingController(IMediator sender)
        {
            _sender = sender;
        }
    }
}
