using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.Controllers;

namespace ShopWebsite.Controllers
{
    public class HomeController : GenericController
    {
        public HomeController(ShopWebsiteContext context) : base(context) { }


        public IActionResult Index()
        {
            GetMenu();

            return View();
        }
    }
}