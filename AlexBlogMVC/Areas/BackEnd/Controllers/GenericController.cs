using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopWebsite.Areas.BackEnd.Filter;

namespace ShopWebsite.Areas.Controllers
{
    [Auth]
    [Area("BackEnd")]
    public class GenericController : Controller
    {
        public readonly BlogMvcContext _context;

        public GenericController(BlogMvcContext context)
        {
            _context = context;
        }

        // 呼叫每一個action都會執行
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.AdminName = "" + HttpContext.Session.GetString("AdminName");
        }


        //取得選單
        public void GetMenu()
        {
            int GroupNum = Convert.ToInt16(HttpContext.Session.GetString("GroupNum"));

            var module = from c in _context.MenuGroups
                         where c.MenuGroupPublish == true
                         orderby c.MenuGroupNum ascending
                         select c;

            ViewBag.module = module.ToList();


            var moduleFun = from c in _context.MenuSubs
            join
                                            s in _context.AdminRoles on c.MenuSubNum equals s.MenuSubNum
                            where c.MenuSubPublish == true && s.GroupNum == GroupNum
                            select c;


            ViewBag.moduleFun = moduleFun.ToList();
        }
    }
}
