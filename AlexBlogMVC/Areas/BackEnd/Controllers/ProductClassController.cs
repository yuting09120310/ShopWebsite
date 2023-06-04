using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.Areas.Controllers
{
    public class ProductClassController : GenericController
    {
        int menuSubNum = 8;

        public ProductClassController(BlogMvcContext context) : base(context) { }


        // GET: ProductClass
        public async Task<IActionResult> Index()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "R"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

            IEnumerable<ProductClassViewModel> viewModel = from n in _context.ProductClasses
                                                           select new ProductClassViewModel
                                                           {
                                                               ProductClassNum = n.ProductClassNum,
                                                               ProductClassName = n.ProductClassName,
                                                               CreateTime = n.CreateTime,
                                                               ProductClassPublish = n.ProductClassPublish
                                                           };

            return View(viewModel);
        }


        // GET: ProductClass/Create
        public IActionResult Create()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

            ProductClassViewModel productClassViewModel = new ProductClassViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };

            return View(productClassViewModel);
        }


        // POST: ProductClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=31759menuSubNum.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductClassViewModel productClassViewModel)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion


            if (ModelState.IsValid)
            {
                ProductClass productClass = new ProductClass
                {
                    ProductClassName = productClassViewModel.ProductClassName,
                    ProductClassSort = productClassViewModel.ProductClassSort,
                    ProductClassPublish = productClassViewModel.ProductClassPublish,
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                };

                _context.Add(productClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productClassViewModel);
        }

        // GET: ProductClass/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

            if (id == null)
            {
                return NotFound();
            }

            //進入DB搜尋資料
            var productClassViewModel = (
                from productClasses in _context.ProductClasses
                where productClasses.ProductClassNum == id
                select new ProductClassViewModel
                {
                    ProductClassPublish = productClasses.ProductClassPublish,
                    ProductClassSort = productClasses.ProductClassSort,
                    ProductClassId = productClasses.ProductClassId,
                    ProductClassName = productClasses.ProductClassName,
                    ProductClassLevel = productClasses.ProductClassLevel,
                    ProductClassPre = productClasses.ProductClassPre,
                    ProductClassNum = productClasses.ProductClassNum,

                    CreateTime = productClasses.CreateTime,
                    Creator = productClasses.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == productClasses.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = productClasses.EditTime,
                    Editor = productClasses.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == productClasses.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = productClasses.Ip,
                }
            ).FirstOrDefault();


            return View(productClassViewModel);
        }

        // POST: ProductClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=31759menuSubNum.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductClassViewModel productClassViewModel)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion


            if (ModelState.IsValid)
            {
                try
                {
                    //將資料寫入db
                    ProductClass newsClass = new ProductClass()
                    {
                        ProductClassNum = productClassViewModel.ProductClassNum,
                        ProductClassSort = productClassViewModel.ProductClassSort,
                        ProductClassId = productClassViewModel.ProductClassId,
                        ProductClassName = productClassViewModel.ProductClassName,
                        ProductClassLevel = productClassViewModel.ProductClassLevel,
                        ProductClassPre = productClassViewModel.ProductClassPre,
                        ProductClassPublish = productClassViewModel.ProductClassPublish,
                        CreateTime = productClassViewModel.CreateTime,
                        Creator = productClassViewModel.Creator,
                        EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                        Ip = productClassViewModel.Ip,
                    };


                    _context.Update(newsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductClassExists(productClassViewModel.ProductClassNum))
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

            return View(productClassViewModel);
        }

        // GET: ProductClass/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "D"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion


            if (id == null || _context.ProductClasses == null)
            {
                return NotFound();
            }

            var productClass = await _context.ProductClasses
                .FirstOrDefaultAsync(m => m.ProductClassNum == id);
            if (productClass == null)
            {
                return NotFound();
            }

            return View(productClass);
        }

        // POST: ProductClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ProductClasses == null)
            {
                return Problem("Entity set 'BlogMvcContext.ProductClasses'  is null.");
            }
            var productClass = await _context.ProductClasses.FindAsync(id);
            if (productClass != null)
            {
                _context.ProductClasses.Remove(productClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductClassExists(long id)
        {
          return (_context.ProductClasses?.Any(e => e.ProductClassNum == id)).GetValueOrDefault();
        }
    }
}
