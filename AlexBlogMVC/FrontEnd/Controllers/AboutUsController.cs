using Microsoft.AspNetCore.Mvc;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
