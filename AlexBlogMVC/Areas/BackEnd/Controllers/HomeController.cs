using AlexBlogMVC.Areas.Controllers;
using AlexBlogMVC.Areas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlexBlogMVC.Controllers
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
            getMenu();

            return View();
        }
    }
}