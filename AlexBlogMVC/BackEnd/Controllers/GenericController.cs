using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

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




        public class CheckRoleAttribute : ActionFilterAttribute
        {
            private int _menuSubNum;
            private string _action;

            public CheckRoleAttribute(int menuSubNum, string action)
            {
                _menuSubNum = menuSubNum;
                _action = action;
            }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var controller = context.Controller as GenericController;
                if (controller != null)
                {
                    controller.CheckRole(_menuSubNum, _action);
                }

                base.OnActionExecuting(context);

            }
        }

        protected void CheckRole(int menuSubNum, string action)
        {
            var role = _context.AdminRoles.Where(x => x.GroupNum == 1 && x.MenuSubNum == menuSubNum && x.Role.Contains(action));
            if (!role.Any())
            {
                TempData["ErrorMessage"] = "您沒有權限執行此操作。";
            }
        }
    }
}
