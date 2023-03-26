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
    public class BannerController : GenericController
    {

        public BannerController(BlogMvcContext context):base(context)
        {
            getMenu();
        }

        // GET: Banner
        public async Task<IActionResult> Index()
        {
              return _context.Banners != null ? 
                          View(await _context.Banners.ToListAsync()) :
                          Problem("Entity set 'BlogMvcContext.Banners'  is null.");
        }

        // GET: Banner/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Banners == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.BannerNum == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BannerNum,Lang,ProductClass,BannerSort,BannerTitle,BannerDescription,BannerContxt,BannerImg1,BannerImgUrl,BannerImgAlt,BannerPublish,BannerPutTime,CreateTime,Creator,EditTime,Editor,Ip,BannerOffTime")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banner/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Banners == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BannerNum,Lang,ProductClass,BannerSort,BannerTitle,BannerDescription,BannerContxt,BannerImg1,BannerImgUrl,BannerImgAlt,BannerPublish,BannerPutTime,CreateTime,Creator,EditTime,Editor,Ip,BannerOffTime")] Banner banner)
        {
            if (id != banner.BannerNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.BannerNum))
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
            return View(banner);
        }

        // GET: Banner/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Banners == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.BannerNum == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Banners == null)
            {
                return Problem("Entity set 'BlogMvcContext.Banners'  is null.");
            }
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(long id)
        {
          return (_context.Banners?.Any(e => e.BannerNum == id)).GetValueOrDefault();
        }
    }
}
