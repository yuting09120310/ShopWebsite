using AlexBlogMVC.Areas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlexBlogMVC.Areas.Controllers
{
    public class LoginController : Controller
    {
        private readonly BlogMvcContext _context;

        public LoginController(BlogMvcContext context) 
        {
            _context= context;
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
                return View();
            }

            //更新最後登入日期
            admin.LastLogin = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _context.SaveChanges();

            HttpContext.Session.SetString("AdminNum", admin.AdminNum.ToString());
            HttpContext.Session.SetString("AdminName", admin.AdminName.ToString());
            HttpContext.Session.SetString("GroupNum", admin.GroupNum.ToString());

            return RedirectToAction("Index", "Home");
        }
    }
}
