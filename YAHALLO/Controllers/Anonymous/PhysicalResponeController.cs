using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using YAHALLO.Application.ResponeTypes;
using YAHALLO.Services;

namespace YAHALLO.Controllers.Anonymous
{
    [Route("services")]
    public class PhysicalResponeController : ControllerBase
    {
        private readonly IWebHostEnvironment _evn;

        public PhysicalResponeController(IWebHostEnvironment evn)
        {
            _evn = evn;
        }
        [HttpGet]
        [Route("image")]
        [Produces(MediaTypeNames.Image.Jpeg, MediaTypeNames.Image.Gif)]
        public IActionResult Image([FromQuery] string filepath)
        {
            var path = Path.Combine(_evn.ContentRootPath, filepath);
            return PhysicalFile(path, "image/jpeg");
        }
    }
}
