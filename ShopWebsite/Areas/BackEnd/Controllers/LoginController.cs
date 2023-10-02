using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 登入控制器，用於處理登入相關的操作。
    /// </summary>
    [Area("BackEnd")]
    public class LoginController : Controller
    {
        public ShopWebsiteContext _context;


        /// <summary>
        /// 建構函式，初始化一個新的 LoginController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public LoginController(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 顯示登入頁面的動作方法（GET）。
        /// </summary>
        /// <returns>登入頁面的視圖。</returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 處理登入請求的動作方法（POST）。
        /// </summary>
        /// <param name="account">輸入的帳號。</param>
        /// <param name="password">輸入的密碼。</param>
        /// <returns>如果登入成功，則重定向到首頁；如果登入失敗，則返回登入頁面並顯示錯誤消息。</returns>
        [HttpPost]
        public IActionResult Index(string account, string password)
        {
            // 在資料庫中查找匹配帳號和密碼的管理員
            Admin? admin = _context.Admins.Where(x => x.AdminAcc == account && x.AdminPwd == password).FirstOrDefault();

            if (admin == null)
            {
                TempData["ErrorMessage"] = "登入失敗，請檢查帳號和密碼。";
                return View();
            }

            // 更新最後登入日期
            admin.LastLogin = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _context.SaveChanges();

            // 設定登入相關的 Session 變數
            HttpContext.Session.SetString("AdminNum", admin.AdminNum.ToString());
            HttpContext.Session.SetString("AdminName", admin.AdminName.ToString());
            HttpContext.Session.SetString("GroupNum", admin.GroupNum.ToString());

            // 登入成功後重定向到首頁
            return RedirectToAction("Index", "Home");
        }
    }

}
