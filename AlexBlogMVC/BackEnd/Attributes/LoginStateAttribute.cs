using AlexBlogMVC.BackEnd.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.BackEnd.Attributes
{
    // 權限判斷
    public class LoginStateAttribute : ActionFilterAttribute
    {
        private int _menuSubNum;
        private string _action;

        public LoginStateAttribute(int menuSubNum, string action)
        {
            _menuSubNum = menuSubNum;
            _action = action;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as GenericController;

            if (controller != null)
            {
                bool res = false;
                res = controller.LoginState();

                // 如果沒登入 就直接retrue
                if (res == false)
                {
                    return;
                }

                // 如果沒權限 就直接retrue
                res = controller.CheckRole(_menuSubNum, _action);
                if (res == false)
                {
                    return;
                }
            }

            base.OnActionExecuting(context);

        }

    }
}
