using Microsoft.AspNetCore.Mvc;
using AlexBlogMVC.FrontEnd.ViewModel;
using AlexBlogMVC.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class AboutUsController : GenericController
    {


        /// <summary>
        /// AboutUsController 的建構函式。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public AboutUsController(BlogMvcContext context) : base(context) { }


        /// <summary>
        /// 在動作執行之前執行的方法。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetBanner();
            GetNewsType();
        }


        /// <summary>
        /// 返回關於我頁面的動作方法。
        /// </summary>
        /// <returns>包含關於我頁面資料的視圖。</returns>
        public IActionResult Index()
        {
            // 建立一個 AboutUsPageViewModel 物件，用於封裝關於我頁面的資料
            var viewModel = new AboutUsPageViewModel();

            // 設定關於我頁面的標題
            viewModel.Title = "關於我";

            // 設定關於我頁面的描述
            viewModel.Description = "歡迎來到我的網站！無論您需要一個個人網站、企業網站還是電子商務平台，我都能為您提供量身定制的解決方案。致力於提供優質的網站設計和開發服務。無論您是創業初期還是大型企業，都有適合您的解決方案。讓我們一同打造出色的網站，助您在線世界中取得成功！";

            // 將封裝好的關於我頁面資料傳遞給 View 方法，並將其作為回應返回
            return View(viewModel);
        }

    }
}
