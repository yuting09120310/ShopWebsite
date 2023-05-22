using Microsoft.AspNetCore.Mvc;
using AlexBlogMVC.FrontEnd.ViewModel;
using AlexBlogMVC.Areas.Models;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class AboutUsController : GenericController
    {

        public AboutUsController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            getBanner();

            var viewModel = new AboutUsPageViewModel();
            viewModel.Title = "關於我們";
            viewModel.Description = "歡迎來到我們的網站！我們是一個致力於提供高品質網站解決方案的團隊。無論您需要一個個人網站、企業網站還是電子商務平台，我們都能為您提供量身定制的解決方案。我們的團隊由專業的網站開發人員和設計師組成，致力於提供優質的網站設計和開發服務。無論您是創業初期還是大型企業，我們都有適合您的解決方案。讓我們一同打造出色的網站，助您在線世界中取得成功！";

            return View(viewModel);
        }
    }
}
