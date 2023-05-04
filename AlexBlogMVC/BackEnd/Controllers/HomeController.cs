using AlexBlogMVC.BackEnd.Controllers;
using AlexBlogMVC.BackEnd.Models;
using AlexBlogMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlexBlogMVC.Controllers
{
    public class HomeController : GenericController
    {
        public HomeController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(1, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            return View();
        }

    }
}