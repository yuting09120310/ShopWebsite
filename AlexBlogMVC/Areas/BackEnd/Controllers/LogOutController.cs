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
            HttpContext.Session.Remove("AdminNum"); 
            HttpContext.Session.Remove("AdminName"); 
            HttpContext.Session.Remove("GroupNum");

            return RedirectToAction("Index", "Login");
        }
    }
}
