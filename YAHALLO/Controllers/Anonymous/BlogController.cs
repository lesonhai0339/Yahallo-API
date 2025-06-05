using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers.Anonymous
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
