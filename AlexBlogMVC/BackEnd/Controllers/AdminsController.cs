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


        // GET: Admins
        public async Task<IActionResult> Index()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(1, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();


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
                admin.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));
                admin.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }


        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(1,"U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            //如果傳進來的id是空的 就返回找不到
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            //進入DB搜尋資料
            var admin = await _context.Admins.FindAsync(id);

            //如果搜尋是空的 就返回找不到
            if (admin == null)
            {
                return NotFound();
            }

            //清空密碼
            admin.AdminPwd = null;
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
                    admin.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));
                    admin.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
