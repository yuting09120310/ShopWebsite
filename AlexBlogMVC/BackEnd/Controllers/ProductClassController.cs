using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class ProductClassController : GenericController
    {

        public ProductClassController(BlogMvcContext context) : base(context) { }


        // GET: ProductClass
        public async Task<IActionResult> Index()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "R"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            return _context.ProductClasses != null ? 
                          View(await _context.ProductClasses.ToListAsync()) :
                          Problem("Entity set 'BlogMvcContext.ProductClasses'  is null.");
        }


        // GET: ProductClass/Create
        public IActionResult Create()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            return View();
        }


        // POST: ProductClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductClassNum,ProductClassSort,ProductClassId,ProductClassName,ProductClassLevel,ProductClassPre,ProductClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] ProductClass productClass)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "C"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            if (ModelState.IsValid)
            {
                _context.Add(productClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productClass);
        }

        // GET: ProductClass/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            if (id == null || _context.ProductClasses == null)
            {
                return NotFound();
            }

            var productClass = await _context.ProductClasses.FindAsync(id);
            if (productClass == null)
            {
                return NotFound();
            }
            return View(productClass);
        }

        // POST: ProductClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProductClassNum,ProductClassSort,ProductClassId,ProductClassName,ProductClassLevel,ProductClassPre,ProductClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] ProductClass productClass)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
            #endregion


            if (id != productClass.ProductClassNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductClassExists(productClass.ProductClassNum))
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
            return View(productClass);
        }

        // GET: ProductClass/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(8, "D"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            getMenu();
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
