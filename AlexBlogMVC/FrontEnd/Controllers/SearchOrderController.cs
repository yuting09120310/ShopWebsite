using AlexBlogMVC.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class SearchOrderController : GenericController
    {

        public SearchOrderController(BlogMvcContext context) : base(context) { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getBanner();
            getNewsType();
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SearchResult(string OrderID)
        {
            return View();
        }
    }
}
