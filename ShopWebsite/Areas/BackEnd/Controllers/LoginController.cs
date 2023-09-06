using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.Areas.Controllers
{
    [Area("BackEnd")]
    public class LoginController : Controller
    {
        public ShopWebsiteContext _context;


        public LoginController(ShopWebsiteContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string account, string password)
        {
            Admin? admin = _context.Admins.Where(x => x.AdminAcc == account && x.AdminPwd == password).FirstOrDefault();

            if(admin == null)
            {
                TempData["ErrorMessage"] = "登入失敗，請檢查帳號和密碼。";
                return View();
            }

            //更新最後登入日期
            admin.LastLogin = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _context.SaveChanges();

            HttpContext.Session.SetString("AdminNum", admin.AdminNum.ToString());
            HttpContext.Session.SetString("AdminName", admin.AdminName.ToString());
            HttpContext.Session.SetString("GroupNum", admin.GroupNum.ToString());

            return RedirectToAction("Index", "Home" );
        }
    }
}
