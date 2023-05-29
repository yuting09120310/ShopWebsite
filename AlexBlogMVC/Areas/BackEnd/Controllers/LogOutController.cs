using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.Areas.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AlexBlogMVC.Areas.BackEnd.Controllers
{
    public class LogOutController : GenericController
    {

        public LogOutController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
