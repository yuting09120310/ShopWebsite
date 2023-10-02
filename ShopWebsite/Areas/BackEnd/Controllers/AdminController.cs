using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 管理員控制器，用於處理與管理員相關的操作。
    /// </summary>
    public class AdminController : GenericController
    {

        IAdminRepository _adminRepository;


        /// <summary>
        /// 建構函式，初始化一個新的 AdminController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public AdminController(ShopWebsiteContext context) : base(context)
        {
            _adminRepository = new AdminRepository(_context);
        }


        /// <summary>
        /// 顯示管理員列表的動作方法。
        /// </summary>
        /// <returns>包含管理員列表的視圖。</returns>
        public IActionResult Index()
        {
            GetMenu();

            // 取得管理員列表的 ViewModel
            List<AdminIndexViewModel> viewModel = _adminRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示創建管理員的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含創建管理員表單的視圖。</returns>
        public async Task<IActionResult> Create()
        {
            GetMenu();

            // 取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

            // 創建 AdminCreateViewModel
            AdminCreateViewModel viewModel = _adminRepository.Create();

            return View(viewModel);
        }


        /// <summary>
        /// 創建管理員的動作方法（POST）。
        /// </summary>
        /// <param name="adminViewModel">包含要創建的管理員資訊的 ViewModel。</param>
        /// <returns>創建成功後重定向到管理員列表，否則顯示創建表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateViewModel adminViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 創建管理員並轉向管理員列表
                _adminRepository.Create(adminViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // 取得群組選單資料
                ViewBag.adminGroup = _adminRepository.GetAdminGroups();

                return View(adminViewModel);
            }
        }


        /// <summary>
        /// 編輯管理員資訊的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的管理員的編號。</param>
        /// <returns>包含管理員編輯表單的視圖，如果找不到管理員則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            // 如果傳進來的 id 為空，返回 NotFound
            if (id == null)
            {
                return NotFound();
            }

            // 取得管理員編輯的 ViewModel
            AdminEditViewModel adminViewModel = _adminRepository.Edit(id);

            // 如果搜尋為空，返回 NotFound
            if (adminViewModel == null)
            {
                return NotFound();
            }

            // 取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

            return View(adminViewModel);
        }


        /// <summary>
        /// 編輯管理員資訊的動作方法（POST）。
        /// </summary>
        /// <param name="adminViewModel">包含要編輯的管理員資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到管理員列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminEditViewModel adminViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 編輯管理員資訊並轉向管理員列表
                _adminRepository.Edit(adminViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(adminViewModel);
            }
        }


        /// <summary>
        /// 刪除管理員的動作方法。
        /// </summary>
        /// <param name="id">要刪除的管理員的編號。</param>
        /// <returns>包含刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long id)
        {
            GetMenu();

            // 刪除指定 id 
            string res = _adminRepository.Delete(id);

            return Json(res);
        }


        /// <summary>
        /// 確認刪除管理員的動作方法。
        /// </summary>
        /// <param name="id">要確認刪除的管理員的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 刪除指定 id 
            _adminRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }


        private bool AdminExists(long id)
        {
            return (_context.Admins?.Any(e => e.AdminNum == id)).GetValueOrDefault();
        }
    }
}
