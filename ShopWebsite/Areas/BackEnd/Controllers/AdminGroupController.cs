using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel;
using System.Data;

namespace ShopWebsite.Areas.Controllers
{

    /// <summary>
    /// 管理員群組控制器，用於處理與管理員群組相關的操作。
    /// </summary>
    public class AdminGroupController : GenericController
    {
        IAdminGroupRepository _adminGroupRepository;


        /// <summary>
        /// 建構函式，初始化一個新的 AdminGroupController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public AdminGroupController(ShopWebsiteContext context) : base(context)
        {
            _adminGroupRepository = new AdminGroupRepository(context);
        }


        /// <summary>
        /// 顯示管理員群組列表的動作方法。
        /// </summary>
        /// <returns>包含管理員群組列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得管理員群組列表的 ViewModel
            List<AdminGroupIndexViewModel> viewModel = _adminGroupRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示創建管理員群組的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含創建管理員群組表單的視圖。</returns>
        public async Task<IActionResult> Create()
        {
            GetMenu();

            // 創建 AdminGroupCreateViewModel
            AdminGroupCreateViewModel adminGroupViewModel = _adminGroupRepository.Create();

            return View(adminGroupViewModel);
        }


        /// <summary>
        /// 創建管理員群組的動作方法（POST）。
        /// </summary>
        /// <param name="Collection">包含創建管理員群組的資訊的表單數據。</param>
        /// <returns>創建成功後重定向到管理員群組列表。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection Collection)
        {
            GetMenu();

            long AdminNum = Convert.ToInt64(HttpContext.Session.GetString("AdminNum"));

            // 創建管理員群組並轉向管理員群組列表
            _adminGroupRepository.Create(Collection, AdminNum);

            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// 編輯管理員群組的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的管理員群組的編號。</param>
        /// <returns>包含管理員群組編輯表單的視圖，如果找不到管理員群組則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            // 取得管理員群組編輯的 ViewModel
            AdminGroupEditViewModel adminGroupViewModel = _adminGroupRepository.Edit(id);

            return View(adminGroupViewModel);
        }


        /// <summary>
        /// 編輯管理員群組的動作方法（POST）。
        /// </summary>
        /// <param name="Collection">包含編輯管理員群組的資訊的表單數據。</param>
        /// <returns>編輯成功後重定向到管理員群組列表。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection Collection)
        {
            GetMenu();

            long AdminNum = Convert.ToInt64(HttpContext.Session.GetString("AdminNum"));

            // 編輯管理員群組資訊並轉向管理員群組列表
            _adminGroupRepository.Edit(Collection, AdminNum);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// 刪除管理員群組的動作方法（GET）。
        /// </summary>
        /// <param name="id">要刪除的管理員群組的編號。</param>
        /// <returns>包含刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的管理員群組
            string result = _adminGroupRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確認刪除管理員群組的動作方法。
        /// </summary>
        /// <param name="id">要確認刪除的管理員群組的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的管理員群組
            _adminGroupRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }


        private bool AdminGroupExists(long id)
        {
            return (_context.AdminGroups?.Any(e => e.GroupNum == id)).GetValueOrDefault();
        }
    }

}
