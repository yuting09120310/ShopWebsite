using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.ViewModel;
using System.Collections.Generic;

namespace ShopWebsite.Areas.Controllers
{
    public class ProductController : GenericController
    {

        IProcutRepository _procutRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _procutRepository = new ProductRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<ProductViewModel> viewModel = _procutRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();

            ProductViewModel newsViewModel = _procutRepository.Create();

            //取得分類選單資料
            ViewBag.newsClass = _procutRepository.GetClassList();

            return View(newsViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                //接收檔案
                if (productViewModel.FileData != null)
                {
                    var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Product");
                    if (!Directory.Exists(direPath))
                    {
                        Directory.CreateDirectory(direPath);
                    }


                    var filePath = Path.Combine(direPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productViewModel.FileData.CopyToAsync(fileStream);
                    }
                }

                Product product = new Product()
                {
                    ProductClass = productViewModel.ProductClass,
                    ProductTitle = productViewModel.ProductTitle,
                    ProductDescription = productViewModel.ProductDescription,
                    ProductContxt = productViewModel.ProductContxt,
                    ProductImg1 = fileName,
                    ProductPublish = productViewModel.ProductPublish,
                    ProductPutTime = productViewModel.ProductPutTime,
                    ProductOffTime = productViewModel.ProductOffTime,
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ProductPrice = productViewModel.ProductPrice,
                    Tag = productViewModel.Tag,
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
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

            //進入DB搜尋資料
            var productViewModel = (
                from products in _context.Products
                where products.ProductNum == id
                select new ProductViewModel
                {
                    ProductNum = products.ProductNum,
                    ProductTitle = products.ProductTitle,
                    ProductClass = products.ProductClass,
                    ProductDescription = products.ProductDescription,
                    ProductContxt = products.ProductContxt,
                    ProductPublish = products.ProductPublish,
                    ProductPutTime = products.ProductPutTime,
                    ProductOffTime = products.ProductOffTime,
                    CreateTime = products.CreateTime,
                    Creator = products.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == products.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = products.EditTime,
                    Editor = products.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == products.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = products.Ip,
                    ProductImg1 = products.ProductImg1,
                    ProductPrice = products.ProductPrice,
                    Tag = products.Tag
                }
            ).FirstOrDefault();

            if (productViewModel.ProductImg1 != null)
            {
                productViewModel.FileData = new FormFile(new MemoryStream(), 0, 0, productViewModel.ProductImg1.ToString(), productViewModel.ProductImg1.ToString());
            }


            if (productViewModel == null)
            {
                return NotFound();
            }


            //取得分類選單資料
            ViewBag.newsClass = await _context.ProductClasses
                                    .Where(g => g.ProductClassPublish == true)
                                    .Select(g => new SelectListItem { Text = g.ProductClassName, Value = g.ProductClassNum.ToString() })
                                    .ToListAsync();


            return View(productViewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                    //接收檔案
                    if (productViewModel.FileData != null)
                    {
                        var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Product");
                        if (!Directory.Exists(direPath))
                        {
                            Directory.CreateDirectory(direPath);
                        }


                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Product", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await productViewModel.FileData.CopyToAsync(fileStream);
                        }
                    }

                    //將資料寫入db
                    Product product = new Product()
                    {
                        ProductNum = productViewModel.ProductNum,
                        ProductTitle = productViewModel.ProductTitle,
                        ProductClass = productViewModel.ProductClass,
                        ProductDescription = productViewModel.ProductDescription,
                        ProductContxt = productViewModel.ProductContxt,
                        ProductPublish = productViewModel.ProductPublish,
                        ProductPutTime = productViewModel.ProductPutTime,
                        ProductOffTime = productViewModel.ProductOffTime,
                        CreateTime = productViewModel.CreateTime,
                        Creator = productViewModel.Creator,
                        EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                        Ip = productViewModel.Ip,
                        ProductPrice = productViewModel.ProductPrice,
                        Tag = productViewModel.Tag,
                    };

                    if (productViewModel.FileData != null)
                    {
                        product.ProductImg1 = fileName;
                    }
                    else
                    {
                        product.ProductImg1 = productViewModel.ProductImg1;
                    }


                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productViewModel.ProductNum))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductNum == id);

            string res = JsonConvert.SerializeObject(product);

            return Json(res);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShopWebsiteContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();

            //取得該篇廣告的圖片並刪除
            var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Product");
            var filePath = Path.Combine(direPath, product.ProductImg1);
            System.IO.File.Delete(filePath);

            return Json("刪除完成");
        }

        private bool ProductExists(long id)
        {
          return (_context.Products?.Any(e => e.ProductNum == id)).GetValueOrDefault();
        }
    }
}
