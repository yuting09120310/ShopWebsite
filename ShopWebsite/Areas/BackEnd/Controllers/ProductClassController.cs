using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 產品類別控制器，用於處理產品類別相關的操作。
    /// </summary>
    public class ProductClassController : GenericController
    {
        IProductClassRepository _productClassRepository;


        /// <summary>
        /// 建構函式，初始化一個新的 ProductClassController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public ProductClassController(ShopWebsiteContext context) : base(context)
        {
            _productClassRepository = new ProductClassRepository(context);
        }


        /// <summary>
        /// 顯示產品類別列表的動作方法（GET）。
        /// </summary>
        /// <returns>包含產品類別列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得產品類別列表的 ViewModel
            List<ProductClassIndexViewModel> viewModel = _productClassRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示建立產品類別的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含建立產品類別表單的視圖。</returns>
        public IActionResult Create()
        {
            GetMenu();

            // 建立新的產品類別 ViewModel
            ProductClassCreateViewModel productClassViewModel = _productClassRepository.Create();

            return View(productClassViewModel);
        }


        /// <summary>
        /// 建立產品類別的動作方法（POST）。
        /// </summary>
        /// <param name="productClassViewModel">包含要建立的產品類別資訊的 ViewModel。</param>
        /// <returns>建立成功後重定向到產品類別列表，否則顯示建立表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductClassCreateViewModel productClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 建立新的產品類別並轉向產品類別列表
                _productClassRepository.Create(productClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(productClassViewModel);
        }

        /// <summary>
        /// 顯示編輯產品類別的表單的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的產品類別的編號。</param>
        /// <returns>包含編輯產品類別表單的視圖，如果找不到產品類別則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            // 取得編輯的產品類別 ViewModel
            ProductClassEditViewModel productClassViewModel = _productClassRepository.Edit(id);

            return View(productClassViewModel);
        }


        /// <summary>
        /// 編輯產品類別的動作方法（POST）。
        /// </summary>
        /// <param name="productClassViewModel">包含要編輯的產品類別資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到產品類別列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductClassEditViewModel productClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 編輯產品類別並轉向產品類別列表
                _productClassRepository.Edit(productClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(productClassViewModel);
        }


        /// <summary>
        /// 顯示詢問刪除產品類別的視窗的動作方法（GET）。
        /// </summary>
        /// <param name="id">要刪除的產品類別的編號。</param>
        /// <returns>包含詢問刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的產品類別
            string result = _productClassRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確定刪除產品類別的動作方法（POST）。
        /// </summary>
        /// <param name="id">要確認刪除的產品類別的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的產品類別
            _productClassRepository.DeleteConfirmed(id);

            return Json("刪除完成");
        }


        private bool ProductClassExists(long id)
        {
            return (_context.ProductClasses?.Any(e => e.ProductClassNum == id)).GetValueOrDefault();
        }
    }

}
