using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    /// <summary>
    /// 登出控制器，用於處理登出相關的操作。
    /// </summary>
    [Area("BackEnd")]
    public class LogOutController : Controller
    {
        /// <summary>
        /// 執行登出操作，清除相關的 Session 變數，然後重定向到登入頁面。
        /// </summary>
        /// <returns>重定向到登入頁面。</returns>
        public IActionResult Index()
        {
            // 移除相關的 Session 變數以實現登出
            HttpContext.Session.Remove("AdminNum");
            HttpContext.Session.Remove("AdminName");
            HttpContext.Session.Remove("GroupNum");

            // 重定向到登入頁面
            return RedirectToAction("Index", "Login");
        }
    }

}
