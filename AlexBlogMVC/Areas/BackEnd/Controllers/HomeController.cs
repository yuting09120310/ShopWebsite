using ShopWebsite.Areas.Controllers;
using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Controllers
{
    public class HomeController : GenericController
    {
        public HomeController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            GetMenu();

            return View();
        }
    }
}