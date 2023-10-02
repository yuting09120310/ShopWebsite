using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 新聞控制器，用於處理新聞相關的操作。
    /// </summary>
    public class NewsController : GenericController
    {
        INewsRepository _newsRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;

        /// <summary>
        /// 建構函式，初始化一個新的 NewsController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        /// <param name="hostingEnvironment">應用程式的主機環境。</param>
        public NewsController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _newsRepository = new NewsRepository(context);
        }


        /// <summary>
        /// 顯示新聞列表的動作方法。
        /// </summary>
        /// <returns>包含新聞列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得新聞列表的 ViewModel
            List<NewsIndexViewModel> viewModel = _newsRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示創建新聞的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含創建新聞表單的視圖。</returns>
        public async Task<IActionResult> Create()
        {
            GetMenu();

            // 創建 NewsCreateViewModel
            NewsCreateViewModel newsViewModel = _newsRepository.Create();

            // 取得分類選單資料
            ViewBag.newsClass = _newsRepository.GetNewsClasseList();

            return View(newsViewModel);
        }


        /// <summary>
        /// 創建新聞的動作方法（POST）。
        /// </summary>
        /// <param name="newsViewModel">包含要創建的新聞資訊的 ViewModel。</param>
        /// <returns>創建成功後重定向到新聞列表，否則顯示創建表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCreateViewModel newsViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 儲存新聞圖片並創建新聞，然後轉向新聞列表
                _newsRepository.SaveFile(newsViewModel.NewsImg1, _hostingEnvironment.WebRootPath);
                _newsRepository.Create(newsViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(newsViewModel);
        }


        /// <summary>
        /// 顯示編輯新聞的表單的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的新聞的編號。</param>
        /// <returns>包含編輯新聞表單的視圖，如果找不到新聞則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            if (id == null)
            {
                return NotFound();
            }

            // 取得編輯的新聞 ViewModel
            NewsEditViewModel newsViewModel = _newsRepository.Edit(id);

            if (newsViewModel == null)
            {
                return NotFound();
            }

            // 取得分類選單資料
            ViewBag.newsClass = _newsRepository.GetNewsClasseList();

            return View(newsViewModel);
        }


        /// <summary>
        /// 編輯新聞的動作方法（POST）。
        /// </summary>
        /// <param name="newsViewModel">包含要編輯的新聞資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到新聞列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsEditViewModel newsViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (newsViewModel.NewsImg1 != null)
                {
                    // 儲存新聞圖片（如果有變更）
                    _newsRepository.SaveFile(newsViewModel.NewsImg1, _hostingEnvironment.WebRootPath);
                }

                // 編輯新聞並轉向新聞列表
                _newsRepository.Edit(newsViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(newsViewModel);
        }


        /// <summary>
        /// 刪除新聞的動作方法。
        /// </summary>
        /// <param name="id">要刪除的新聞的編號。</param>
        /// <returns>包含刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的新聞
            string result = _newsRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確認刪除新聞的動作方法。
        /// </summary>
        /// <param name="id">要確認刪除的新聞的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的新聞
            _newsRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }


        private bool NewsExists(long id)
        {
            return (_context.News?.Any(e => e.NewsNum == id)).GetValueOrDefault();
        }
    }

}
