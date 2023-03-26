using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class AdminsController : GenericController
    {
        private readonly BlogMvcContext _context;
        public AdminsController(BlogMvcContext context) : base(context)
        {
            _context = context;
        }

        //當每個action被執行都會呼叫getMenu
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getMenu();
            base.OnActionExecuting(context);
        }


        // GET: Admins
        public async Task<IActionResult> Index()
        {

            return _context.Admins != null ?
                        View(await _context.Admins.ToListAsync()) :
                        Problem("Entity set 'BlogMvcContext.Admins'  is null.");
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminNum == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminNum,GroupNum,AdminAcc,AdminPwd,AdminName,AdminPublish,LastLogin,CreateTime,Creator,EditTime,Editor,Ip")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("AdminNum,GroupNum,AdminAcc,AdminPwd,AdminName,AdminPublish,LastLogin,CreateTime,Creator,EditTime,Editor,Ip")] Admin admin)
        {
            if (id != admin.AdminNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminNum))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminNum == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Admins == null)
            {
                return Problem("Entity set 'BlogMvcContext.Admins'  is null.");
            }
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(long id)
        {
            return (_context.Admins?.Any(e => e.AdminNum == id)).GetValueOrDefault();
        }
    }
}
