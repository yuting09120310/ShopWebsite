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
    public class NewsController : GenericController
    {
        int menuSubNum = 5;

        public NewsController(BlogMvcContext context) : base(context) { }



        // GET: News
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


            IEnumerable<NewsViewModel> viewModel = from n in _context.News
                                                    select new NewsViewModel
                                                    {
                                                        NewsNum = n.NewsNum,
                                                        NewsTitle = n.NewsTitle,
                                                        NewsDescription = n.NewsDescription,
                                                        NewsImg1 = n.NewsImg1,
                                                        NewsPutTime = n.NewsPutTime,
                                                        CreateTime = n.CreateTime,
                                                        EditTime = n.EditTime,
                                                        NewsOffTime = n.NewsOffTime,
                                                        NewsPublish = n.NewsPublish
                                                    };

            return View(viewModel);
        }


        // GET: News/Create
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

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317menuSubNum98.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsNum,Lang,NewsClass,NewsSort,NewsTitle,NewsDescription,NewsContxt,NewsImg1,NewsImgUrl,NewsImgAlt,NewsPublish,NewsViews,NewsPutTime,CreateTime,Creator,EditTime,Editor,Ip,NewsOffTime")] News news)
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
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/menuSubNum
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

            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/menuSubNum
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317menuSubNum98.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NewsNum,Lang,NewsClass,NewsSort,NewsTitle,NewsDescription,NewsContxt,NewsImg1,NewsImgUrl,NewsImgAlt,NewsPublish,NewsViews,NewsPutTime,CreateTime,Creator,EditTime,Editor,Ip,NewsOffTime")] News news)
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

            if (id != news.NewsNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsNum))
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
            return View(news);
        }

        // GET: News/Delete/menuSubNum
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

            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsNum == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/menuSubNum
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'BlogMvcContext.News'  is null.");
            }
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(long id)
        {
          return (_context.News?.Any(e => e.NewsNum == id)).GetValueOrDefault();
        }
    }
}
