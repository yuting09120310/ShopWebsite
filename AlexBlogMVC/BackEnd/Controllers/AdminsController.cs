using AlexBlogMVC.BackEnd.Attributes;
using AlexBlogMVC.BackEnd.Models;
using AlexBlogMVC.BackEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class AdminsController : GenericController
    {
        public AdminsController(BlogMvcContext context) : base(context){}


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }


        [LoginState(1, "R")]
        [GetMenu]
        // GET: Admins
        public async Task<IActionResult> Index()
        {
            var admins = await _context.Admins.ToListAsync();
            var adminGroups = await _context.AdminGroups.ToListAsync();

            var viewModel = from a in admins
                            join g in adminGroups on a.GroupNum equals g.GroupNum into ag
                            from subg in ag.DefaultIfEmpty()
                            select new AdminViewModel
                            {
                                AdminNum = a.AdminNum,
                                AdminAcc = a.AdminAcc,
                                AdminName = a.AdminName,
                                AdminPublish = a.AdminPublish,
                                AdminPwd = a.AdminPwd,
                                CreateTime = a.CreateTime,
                                Creator = a.Creator,
                                EditTime = a.EditTime,
                                Editor = a.Editor,
                                GroupNum = a.GroupNum,
                                GroupName = subg?.GroupName
                            };

            return View(viewModel);
        }


        [LoginState(1, "C")]
        [GetMenu]
        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [LoginState(1, "C")]
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
        [LoginState(1, "U")]
        [GetMenu]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            admin.AdminPwd = "";
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }


        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [LoginState(1, "U")]
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
        [LoginState(1, "D")]
        [GetMenu]
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
