using AlexBlogMVC.BackEnd.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.BackEnd.Attributes
{
    // 權限判斷
    public class LoginStateAttribute : ActionFilterAttribute
    {
        private int _menuSubNum;
        private string _action;

        /// <summary>
        /// 判斷是否有登入以及權限
        /// </summary>
        /// <param name="menuSubNum">menu的編號</param>
        /// <param name="action">行為(C,R,U,D)</param>
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
