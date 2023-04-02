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
    public class ProductClassController : Controller
    {
        private readonly BlogMvcContext _context;

        public ProductClassController(BlogMvcContext context)
        {
            _context = context;
        }

        // GET: ProductClass
        public async Task<IActionResult> Index()
        {
              return _context.ProductClasses != null ? 
                          View(await _context.ProductClasses.ToListAsync()) :
                          Problem("Entity set 'BlogMvcContext.ProductClasses'  is null.");
        }

        // GET: ProductClass/Details/5
        public async Task<IActionResult> Details(long? id)
        {
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

        // GET: ProductClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductClassNum,ProductClassSort,ProductClassId,ProductClassName,ProductClassLevel,ProductClassPre,ProductClassPublish,CreateTime,Creator,EditTime,Editor,Ip")] ProductClass productClass)
        {
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
