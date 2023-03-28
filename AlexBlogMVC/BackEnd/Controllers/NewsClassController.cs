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
        public NewsClassController(BlogMvcContext context) : base(context) { }


        //當每個action被執行都會呼叫getMenu
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getMenu();
            base.OnActionExecuting(context);
        }



        // GET: NewsClass
        public async Task<IActionResult> Index()
        {
              return _context.NewsClasses != null ? 
                          View(await _context.NewsClasses.ToListAsync()) :
                          Problem("Entity set 'BlogMvcContext.NewsClasses'  is null.");
        }

        // GET: NewsClass/Details/5
        public async Task<IActionResult> Details(long? id)
        {
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

        // GET: NewsClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsClassNum,NewsClassSort,NewsClassId,NewsClassName,NewsClassLevel,NewsClassPre,NewsClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] NewsClass newsClass)
        {
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
