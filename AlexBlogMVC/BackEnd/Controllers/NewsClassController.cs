using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class NewsClassController : GenericController
    {
        int menuSubNum = 6;

        public NewsClassController(BlogMvcContext context) : base(context) { }


        // GET: NewsClass
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
            getMenu();
            #endregion



            return _context.NewsClasses != null ? 
                          View(await _context.NewsClasses.ToListAsync()) :
                          Problem("Entity set 'BlogMvcContext.NewsClasses'  is null.");
        }


        // GET: NewsClass/Create
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
            getMenu();
            #endregion

            return View();
        }

        // POST: NewsClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsClassNum,NewsClassSort,NewsClassId,NewsClassName,NewsClassLevel,NewsClassPre,NewsClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] NewsClass newsClass)
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
            getMenu();
            #endregion


            if (ModelState.IsValid)
            {
                _context.Add(newsClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsClass);
        }

        // GET: NewsClass/Edit/5
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
            getMenu();
            #endregion

            if (id == null || _context.NewsClasses == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClasses.FindAsync(id);
            if (newsClass == null)
            {
                return NotFound();
            }
            return View(newsClass);
        }

        // POST: NewsClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NewsClassNum,NewsClassSort,NewsClassId,NewsClassName,NewsClassLevel,NewsClassPre,NewsClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] NewsClass newsClass)
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
            getMenu();
            #endregion

            if (id != newsClass.NewsClassNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsClassExists(newsClass.NewsClassNum))
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
            return View(newsClass);
        }

        // GET: NewsClass/Delete/5
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
            getMenu();
            #endregion

            if (id == null || _context.NewsClasses == null)
            {
                return NotFound();
            }

            var newsClass = await _context.NewsClasses
                .FirstOrDefaultAsync(m => m.NewsClassNum == id);
            if (newsClass == null)
            {
                return NotFound();
            }

            return View(newsClass);
        }

        // POST: NewsClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.NewsClasses == null)
            {
                return Problem("Entity set 'BlogMvcContext.NewsClasses'  is null.");
            }
            var newsClass = await _context.NewsClasses.FindAsync(id);
            if (newsClass != null)
            {
                _context.NewsClasses.Remove(newsClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsClassExists(long id)
        {
          return (_context.NewsClasses?.Any(e => e.NewsClassNum == id)).GetValueOrDefault();
        }
    }
}
