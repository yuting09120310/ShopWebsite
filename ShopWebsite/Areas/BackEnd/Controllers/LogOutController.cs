using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    [Area("BackEnd")]
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("AdminNum"); 
            HttpContext.Session.Remove("AdminName"); 
            HttpContext.Session.Remove("GroupNum");

            return RedirectToAction("Index", "Login");
        }
    }
}
