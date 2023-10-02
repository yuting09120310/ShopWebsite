using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;

namespace ShopWebsite.Areas.Controllers
{
    /// <summary>
    /// 產品控制器，用於處理產品相關的操作。
    /// </summary>
    public class ProductController : GenericController
    {
        IProductRepository _productRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;


        /// <summary>
        /// 建構函式，初始化一個新的 ProductController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        /// <param name="hostingEnvironment">應用程式的主機環境。</param>
        public ProductController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = new ProductRepository(context);
        }


        /// <summary>
        /// 顯示產品列表的動作方法（GET）。
        /// </summary>
        /// <returns>包含產品列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得產品列表的 ViewModel
            List<ProductIndexViewModel> viewModel = _productRepository.GetList();

            return View(viewModel);
        }


        /// <summary>
        /// 顯示建立產品的表單的動作方法（GET）。
        /// </summary>
        /// <returns>包含建立產品表單的視圖。</returns>
        public IActionResult Create()
        {
            GetMenu();

            // 建立新的產品建立 ViewModel
            ProductCreateViewModel createViewModel = _productRepository.Create();

            // 取得產品分類選單資料
            ViewBag.ProductClass = _productRepository.GetProductClasseList();

            return View(createViewModel);
        }


        /// <summary>
        /// 建立產品的動作方法（POST）。
        /// </summary>
        /// <param name="productViewModel">包含要建立的產品資訊的 ViewModel。</param>
        /// <returns>建立成功後重定向到產品列表，否則顯示建立表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 儲存產品圖片並建立新的產品，然後轉向產品列表
                _productRepository.SaveFile(productViewModel.ProductImg1, _hostingEnvironment.WebRootPath);
                _productRepository.SaveFile(productViewModel.ProductImgList, _hostingEnvironment.WebRootPath);
                _productRepository.Create(productViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }


        /// <summary>
        /// 顯示編輯產品的表單的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的產品的編號。</param>
        /// <returns>包含編輯產品表單的視圖，如果找不到產品則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            if (id == null)
            {
                return NotFound();
            }

            // 取得編輯的產品 ViewModel
            ProductEditViewModel productViewModel = _productRepository.Edit(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            // 取得產品分類選單資料
            ViewBag.ProductClass = _productRepository.GetProductClasseList();

            return View(productViewModel);
        }


        /// <summary>
        /// 編輯產品的動作方法（POST）。
        /// </summary>
        /// <param name="productViewModel">包含要編輯的產品資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到產品列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (productViewModel.ProductImg1 != null)
                {
                    // 儲存新的產品圖片
                    _productRepository.SaveFile(productViewModel.ProductImg1, _hostingEnvironment.WebRootPath);
                }

                // 編輯產品並轉向產品列表
                _productRepository.Edit(productViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }


        /// <summary>
        /// 顯示詢問刪除產品的視窗的動作方法（GET）。
        /// </summary>
        /// <param name="id">要刪除的產品的編號。</param>
        /// <returns>包含詢問刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            // 刪除指定 id 的產品
            string result = _productRepository.Delete(id);

            return Json(result);
        }


        /// <summary>
        /// 確定刪除產品的動作方法（POST）。
        /// </summary>
        /// <param name="id">要確認刪除的產品的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            // 確認刪除指定 id 的產品
            _productRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }


        private bool ProductExists(long id)
        {
            return (_context.Products?.Any(e => e.ProductNum == id)).GetValueOrDefault();
        }
    }

}
