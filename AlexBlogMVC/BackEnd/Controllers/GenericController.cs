using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
