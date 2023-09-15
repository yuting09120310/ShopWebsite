using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;
using System.Collections.Generic;

namespace ShopWebsite.Areas.Controllers
{
    public class ProductController : GenericController
    {

        IProductRepository _productRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _productRepository = new ProductRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<ProductIndexViewModel> viewModel = _productRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();

            ProductCreateViewModel createViewModel = _productRepository.Create();

            //取得分類選單資料
            ViewBag.ProductClass = _productRepository.GetProductClasseList();

            return View(createViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {

                _productRepository.SaveFile(productViewModel.ProductImg1, _hostingEnvironment.WebRootPath);

                _productRepository.Create(productViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            if (id == null)
            {
                return NotFound();
            }


            ProductEditViewModel productViewModel = _productRepository.Edit(id);


            if (productViewModel == null)
            {
                return NotFound();
            }

            //取得分類選單資料
            ViewBag.ProductClass = _productRepository.GetProductClasseList();

            return View(productViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (productViewModel.ProductImg1 != null)
                {
                    _productRepository.SaveFile(productViewModel.ProductImg1, _hostingEnvironment.WebRootPath);
                }

                _productRepository.Edit(productViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _productRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _productRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }

        private bool ProductExists(long id)
        {
          return (_context.Products?.Any(e => e.ProductNum == id)).GetValueOrDefault();
        }
    }
}
