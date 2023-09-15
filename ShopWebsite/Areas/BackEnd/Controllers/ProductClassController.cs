using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel;

namespace ShopWebsite.Areas.Controllers
{
    public class ProductClassController : GenericController
    {
        IProductClassRepository _procutClassRepository;

        public ProductClassController(ShopWebsiteContext context) : base(context) 
        {
            _procutClassRepository = new ProductClassRepository(context);
        }


        // GET: ProductClass
        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<ProductClassIndexViewModel> viewModel = _procutClassRepository.GetList();

            return View(viewModel);
        }


        // GET: ProductClass/Create
        public IActionResult Create()
        {
            GetMenu();

            ProductClassCreateViewModel productClassViewModel = _procutClassRepository.Create();

            return View(productClassViewModel);
        }


        // POST: ProductClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=31759menuSubNum.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductClassCreateViewModel productClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _procutClassRepository.Create(productClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(productClassViewModel);
        }

        // GET: ProductClass/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            ProductClassEditViewModel productClassViewModel = _procutClassRepository.Edit(id);

            return View(productClassViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductClassEditViewModel productClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _procutClassRepository.Edit(productClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(productClassViewModel);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _procutClassRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _procutClassRepository.DeleteConfirmed(id);

            return Json("刪除完成");
        }

        private bool ProductClassExists(long id)
        {
          return (_context.ProductClasses?.Any(e => e.ProductClassNum == id)).GetValueOrDefault();
        }
    }
}
