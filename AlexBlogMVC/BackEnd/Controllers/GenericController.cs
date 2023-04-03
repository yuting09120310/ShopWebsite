using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class GenericController : Controller
    {
        public readonly BlogMvcContext _context;

        public GenericController(BlogMvcContext context)
        {
            _context = context;
        }


        //取得選單
        public void getMenu()
        {
            //int UserRoleId = Convert.ToInt16(HttpContext.Session.GetString("UserRoleId"));

            var module = from c in _context.MenuGroups
                         where c.MenuGroupPublish == true
                         orderby c.MenuGroupNum ascending
                         select c;
            TempData["module"] = module.ToList();


            var moduleFun = from c in _context.MenuSubs
            join
                                            s in _context.AdminRoles on c.MenuSubNum equals s.MenuSubNum
                            where c.MenuSubPublish == true && s.GroupNum == 1
                            select c;

            TempData["moduleFun"] = moduleFun.ToList();
        }


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

                if(controller != null)
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

        public bool LoginState()
        {
            string AdminNum = "" + HttpContext.Session.GetString("AdminNum");
            if (AdminNum.Length == 0)
            {
                TempData["ErrorMessage"] = "<script language='javascript' type='text/javascript'>alert('尚未登入 請先登入。');window.location.href='/Admin/Login/Index';</script>";
                
                return false;
            }
            return true;
        }


        protected bool CheckRole(int menuSubNum, string action)
        {
            var role = _context.AdminRoles.Where(x => x.GroupNum == 1 && x.MenuSubNum == menuSubNum && x.Role.Contains(action));
            if (!role.Any())
            {
                
                TempData["ErrorMessage"] = "<div class=\"alert alert-danger\">您沒有權限執行此操作。</div>";

                return false;
            }

            return true;
        }


        
    }
}
