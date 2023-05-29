using AlexBlogMVC.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class ShopPageController : GenericController
    {

        public ShopPageController(BlogMvcContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getNewsType();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
