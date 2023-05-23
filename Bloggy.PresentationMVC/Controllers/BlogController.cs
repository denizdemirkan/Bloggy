using Microsoft.AspNetCore.Mvc;

namespace Bloggy.PresentationMVC.Controllers
{
    public class BlogController : Controller
    {
        [Route("blog")]
        public IActionResult Index()
        {
            return View();
        }

        // make sure {blogId} is valid! Otherwise give 404
        [Route("blog/{blogId}")]
        public IActionResult Blog(int Id)
        {
            return View(Id);
        }
    }
}
