using Microsoft.AspNetCore.Mvc;

namespace Bloggy.PresentationMVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog(int Id)
        {
            return View();
        }
    }
}
