using Microsoft.AspNetCore.Mvc;
using AlexBlogMVC.FrontEnd.ViewModel;
using AlexBlogMVC.Areas.BackEnd.Models;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class AboutUsController : GenericController
    {

        public AboutUsController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            var viewModel = new AboutUsPageViewModel();
            viewModel.Title = "關於我";
            viewModel.Description = "歡迎來到我的網站！無論您需要一個個人網站、企業網站還是電子商務平台，我都能為您提供量身定制的解決方案。致力於提供優質的網站設計和開發服務。無論您是創業初期還是大型企業，都有適合您的解決方案。讓我們一同打造出色的網站，助您在線世界中取得成功！";

            return View(viewModel);
        }
    }
}
