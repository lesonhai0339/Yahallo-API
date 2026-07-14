using Microsoft.AspNetCore.Mvc;

namespace YAHALLO.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
