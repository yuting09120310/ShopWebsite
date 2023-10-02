using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopWebsite.Areas.BackEnd.Filter;
using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 泛型控制器，用於提供共用的控制器功能。
    /// </summary>
    [Auth]
    [Area("BackEnd")]
    public class GenericController : Controller
    {
        public readonly ShopWebsiteContext _context;

        /// <summary>
        /// 建構函式，初始化一個新的 GenericController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public GenericController(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 在每個 Action 執行前執行的方法，用於設定 ViewBag.AdminName。
        /// </summary>
        /// <param name="context">Action 執行上下文。</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.AdminName = "" + HttpContext.Session.GetString("AdminName");
        }


        /// <summary>
        /// 取得選單資訊並設定 ViewBag.module 和 ViewBag.moduleFun。
        /// </summary>
        public void GetMenu()
        {
            int GroupNum = Convert.ToInt16(HttpContext.Session.GetString("GroupNum"));

            // 取得主選單資訊
            var module = from c in _context.MenuGroups
                         where c.MenuGroupPublish == true
                         orderby c.MenuGroupNum ascending
                         select c;

            ViewBag.module = module.ToList();

            // 取得次選單資訊
            var moduleFun = from c in _context.MenuSubs
                            join s in _context.AdminRoles on c.MenuSubNum equals s.MenuSubNum
                            where c.MenuSubPublish == true && s.GroupNum == GroupNum
                            select c;

            ViewBag.moduleFun = moduleFun.ToList();
        }
    }

}
