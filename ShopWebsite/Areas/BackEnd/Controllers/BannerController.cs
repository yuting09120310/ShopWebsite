using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 廣告控制器，用於處理與廣告相關的操作。
    /// </summary>
    public class BannerController : GenericController
    {
        IBannerRepository _bannerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;


        /// <summary>
        /// 建構函式，初始化一個新的 BannerController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        /// <param name="hostingEnvironment">Web 主機環境。</param>
        public BannerController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _bannerRepository = new BannerRepository(context);
        }


        /// <summary>
        /// 顯示廣告列表的動作方法。
        /// </summary>
        /// <returns>包含廣告列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得廣告列表的 ViewModel
            List<BannerIndexViewModel> viewModel = _bannerRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示創建廣告的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含創建廣告表單的視圖。</returns>
        public async Task<IActionResult> Create()
        {
            GetMenu();

            ViewBag.PageTitle = "新增廣告";

            // 創建 BannerCreateViewModel
            BannerCreateViewModel viewModel = _bannerRepository.Create();

            return View(viewModel);
        }


        /// <summary>
        /// 創建廣告的動作方法（POST）。
        /// </summary>
        /// <param name="bannerViewModel">包含要創建的廣告資訊的 ViewModel。</param>
        /// <returns>創建成功後重定向到廣告列表，否則顯示創建表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerCreateViewModel bannerViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 儲存廣告圖片並創建廣告，然後重定向到廣告列表
                _bannerRepository.SaveFile(bannerViewModel.BannerImg1, _hostingEnvironment.WebRootPath);
                _bannerRepository.Create(bannerViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(bannerViewModel);
        }


        /// <summary>
        /// 編輯廣告的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的廣告的編號。</param>
        /// <returns>包含廣告編輯表單的視圖，如果找不到廣告則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            ViewBag.PageTitle = "編輯廣告";

            if (id == null)
            {
                return NotFound();
            }

            // 取得廣告編輯的 ViewModel
            BannerEditViewModel bannerViewModel = _bannerRepository.Edit(id);

            if (bannerViewModel == null)
            {
                return NotFound();
            }

            return View(bannerViewModel);
        }


        /// <summary>
        /// 編輯廣告的動作方法（POST）。
        /// </summary>
        /// <param name="bannerViewModel">包含要編輯的廣告資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到廣告列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerEditViewModel bannerViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (bannerViewModel.BannerImg1 != null)
                {
                    // 如果有新的廣告圖片，則儲存圖片
                    _bannerRepository.SaveFile(bannerViewModel.BannerImg1, _hostingEnvironment.WebRootPath);
                }

                // 編輯廣告資訊並轉向廣告列表
                _bannerRepository.Edit(bannerViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(bannerViewModel);
        }


        /// <summary>
        /// 刪除廣告的動作方法。
        /// </summary>
        /// <param name="id">要刪除的廣告的編號。</param>
        /// <returns>包含刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的廣告
            string result = _bannerRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確認刪除廣告的動作方法。
        /// </summary>
        /// <param name="id">要確認刪除的廣告的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的廣告
            _bannerRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }

        private bool BannerExists(long id)
        {
            return (_context.Banners?.Any(e => e.BannerNum == id)).GetValueOrDefault();
        }
    }

}
