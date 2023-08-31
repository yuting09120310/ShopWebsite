using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    public class LogOutController : GenericController
    {

        public LogOutController(ShopWebsiteContext context) : base(context) { }


        public IActionResult Index()
        {
            HttpContext.Session.Remove("AdminNum"); 
            HttpContext.Session.Remove("AdminName"); 
            HttpContext.Session.Remove("GroupNum");

            return RedirectToAction("Index", "Login");
        }
    }
}
