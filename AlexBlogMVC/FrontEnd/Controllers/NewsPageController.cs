using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using AlexBlogMVC.BackEnd.ViewModel;
using AlexBlogMVC.FrontEnd.ViewModel;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class NewsPageController : GenericController
    {

        public NewsPageController(BlogMvcContext context) : base(context) { }


        // GET: News
        public async Task<IActionResult> Index()
        {

            IEnumerable<NewsPageViewModel> viewModel = from n in _context.News
                                                       where n.NewsPublish == true
                                                       select new NewsPageViewModel
                                                       {
                                                           Id = n.NewsNum,
                                                           Title = n.NewsTitle,
                                                           Description = n.NewsDescription,
                                                           NewsImg1 = n.NewsImg1,
                                                           CreateTime = n.CreateTime,
                                                           NewsType = (from creator in _context.NewsClasses 
                                                                     where creator.NewsClassNum == n.NewsClass 
                                                                     select creator.NewsClassName).FirstOrDefault(),
                                                       };


            return View(viewModel);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var newsViewModel = (
                from n in _context.News
                where n.NewsNum == id && n.NewsPublish == true
                select new NewsPageViewModel
                {
                    Id = n.NewsNum,
                    Title = n.NewsTitle,
                    Description = n.NewsDescription,
                    NewsImg1 = n.NewsImg1,
                    CreateTime = n.CreateTime,
                    NewsType = (from creator in _context.NewsClasses
                                where creator.NewsClassNum == n.NewsClass
                                select creator.NewsClassName).FirstOrDefault(),
                    contxt = n.NewsContxt,
                }
            ).FirstOrDefault();


            if (newsViewModel == null)
            {
                return NotFound();
            }

            return View(newsViewModel);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsNum,Lang,NewsClass,NewsSort,NewsTitle,NewsDescription,NewsContxt,NewsImg1,NewsImgUrl,NewsImgAlt,NewsPublish,NewsViews,NewsPutTime,CreateTime,Creator,EditTime,Editor,Ip,NewsOffTime")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
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

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("NewsNum,Lang,NewsClass,NewsSort,NewsTitle,NewsDescription,NewsContxt,NewsImg1,NewsImgUrl,NewsImgAlt,NewsPublish,NewsViews,NewsPutTime,CreateTime,Creator,EditTime,Editor,Ip,NewsOffTime")] News news)
        {
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

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
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

        // POST: News/Delete/5
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
