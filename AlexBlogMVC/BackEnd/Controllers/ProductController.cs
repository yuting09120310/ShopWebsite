using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using AlexBlogMVC.BackEnd.ViewModel;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class ProductController : GenericController
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(BlogMvcContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: Product
        public async Task<IActionResult> Index()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "R"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            IEnumerable<ProductViewModel> viewModel = from n in _context.Products
                                                   select new ProductViewModel
                                                   {
                                                       ProductNum = n.ProductNum,
                                                       ProductTitle = n.ProductTitle,
                                                       ProductDescription = n.ProductDescription,
                                                       ProductImg1 = n.ProductImg1,
                                                       ProductPutTime = n.ProductPutTime,
                                                       CreateTime = n.CreateTime,
                                                       EditTime = n.EditTime,
                                                       ProductOffTime = n.ProductOffTime,
                                                       ProductPublish = n.ProductPublish
                                                   };


            return View(viewModel);
        }



        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion

            ProductViewModel newsViewModel = new ProductViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };


            //取得分類選單資料
            ViewBag.newsClass = await _context.ProductClasses
                                    .Where(g => g.ProductClassPublish == true)
                                    .Select(g => new SelectListItem { Text = g.ProductClassName, Value = g.ProductClassNum.ToString() })
                                    .ToListAsync();


            return View(newsViewModel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            if (ModelState.IsValid)
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
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productViewModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(7, "D"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductNum == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'BlogMvcContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
          return (_context.Products?.Any(e => e.ProductNum == id)).GetValueOrDefault();
        }
    }
}
