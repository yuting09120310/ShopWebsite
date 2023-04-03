using AlexBlogMVC.BackEnd.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.BackEnd.Attributes
{
    public class GetMenuAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as GenericController;

            if (controller != null)
            {
                controller.getMenu();
            }

            base.OnActionExecuting(context);
        }
    }
}
