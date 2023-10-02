using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 新聞分類控制器，用於處理新聞分類相關的操作。
    /// </summary>
    public class NewsClassController : GenericController
    {
        INewsClassRepository _newsClassRepository;


        /// <summary>
        /// 建構函式，初始化一個新的 NewsClassController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public NewsClassController(ShopWebsiteContext context) : base(context)
        {
            _newsClassRepository = new NewsClassRepository(context);
        }


        /// <summary>
        /// 顯示新聞分類列表的動作方法。
        /// </summary>
        /// <returns>包含新聞分類列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得新聞分類列表的 ViewModel
            List<NewsClassIndexViewModel> viewModel = _newsClassRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示創建新聞分類的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含創建新聞分類表單的視圖。</returns>
        public IActionResult Create()
        {
            GetMenu();

            // 創建 NewsClassCreateViewModel
            NewsClassCreateViewModel newsClassViewModel = _newsClassRepository.Create();

            return View(newsClassViewModel);
        }


        /// <summary>
        /// 創建新聞分類的動作方法（POST）。
        /// </summary>
        /// <param name="newsClassViewModel">包含要創建的新聞分類資訊的 ViewModel。</param>
        /// <returns>創建成功後重定向到新聞分類列表，否則顯示創建表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsClassCreateViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 創建新聞分類並轉向新聞分類列表
                _newsClassRepository.Create(newsClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(newsClassViewModel);
        }


        /// <summary>
        /// 顯示編輯新聞分類的表單的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的新聞分類的編號。</param>
        /// <returns>包含編輯新聞分類表單的視圖，如果找不到新聞分類則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            // 取得編輯的新聞分類 ViewModel
            NewsClassEditViewModel newsClassViewModel = _newsClassRepository.Edit(id);

            return View(newsClassViewModel);
        }


        /// <summary>
        /// 編輯新聞分類的動作方法（POST）。
        /// </summary>
        /// <param name="newsClassViewModel">包含要編輯的新聞分類資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到新聞分類列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsClassEditViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 編輯新聞分類並轉向新聞分類列表
                _newsClassRepository.Edit(newsClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(newsClassViewModel);
        }


        /// <summary>
        /// 刪除新聞分類的動作方法。
        /// </summary>
        /// <param name="id">要刪除的新聞分類的編號。</param>
        /// <returns>包含刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的新聞分類
            string result = _newsClassRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確認刪除新聞分類的動作方法。
        /// </summary>
        /// <param name="id">要確認刪除的新聞分類的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的新聞分類
            _newsClassRepository.DeleteConfirmed(id);

            return Json("刪除完成");
        }


        private bool NewsClassExists(long id)
        {
            return (_context.NewsClasses?.Any(e => e.NewsClassNum == id)).GetValueOrDefault();
        }
    }
}
