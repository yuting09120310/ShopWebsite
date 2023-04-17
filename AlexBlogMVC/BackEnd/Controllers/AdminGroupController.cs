using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using AlexBlogMVC.BackEnd.Attributes;
using AlexBlogMVC.BackEnd.ViewModel;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class AdminGroupController : GenericController
    {

        public AdminGroupController(BlogMvcContext context) : base(context) { }


        //當每個action被執行都會呼叫getMenu
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }


        // GET: AdminGroup
        public async Task<IActionResult> Index()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(2, "R"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            var admins = await _context.Admins.ToListAsync();
            var adminGroups = await _context.AdminGroups.ToListAsync();

            var viewModel = from g in adminGroups
                            join a1 in admins on g.Creator equals a1.AdminNum into ag1
                            from subg1 in ag1.DefaultIfEmpty()
                            join a2 in admins on g.Editor equals a2.AdminNum into ag2
                            from subg2 in ag2.DefaultIfEmpty()
                            select new AdminGroupViewModel
                            {
                                GroupNum = g.GroupNum,
                                GroupName = g.GroupName,
                                GroupInfo = g.GroupInfo,
                                GroupPublish = g.GroupPublish,
                                CreateTime = g.CreateTime,
                                Creator = g.Creator,
                                EditTime = g.EditTime,
                                Editor = g.Editor,
                                Ip = g.Ip,

                                CreatorName = subg1?.AdminName,
                                EditorName = subg2?.AdminName,
                            };

            return View(viewModel);
        }

        // GET: AdminGroup/Create
        public IActionResult Create()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(2, "C"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            return View();
        }

        // POST: AdminGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupNum,GroupName,GroupInfo,GroupPublish,CreateTime,Creator,EditTime,Editor,Ip")] AdminGroup adminGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminGroup);
        }

        // GET: AdminGroup/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(2, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();


            var adminGroup = await _context.AdminGroups.FindAsync(id);
            if (adminGroup == null)
            {
                return NotFound();
            }
            return View(adminGroup);
        }

        // POST: AdminGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GroupNum,GroupName,GroupInfo,GroupPublish,CreateTime,Creator,EditTime,Editor,Ip")] AdminGroup adminGroup)
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(2, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminGroupExists(adminGroup.GroupNum))
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
            return View(adminGroup);
        }

        // GET: AdminGroup/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(2, "D"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            if (id == null || _context.AdminGroups == null)
            {
                return NotFound();
            }

            var adminGroup = await _context.AdminGroups
                .FirstOrDefaultAsync(m => m.GroupNum == id);
            if (adminGroup == null)
            {
                return NotFound();
            }

            return View(adminGroup);
        }

        // POST: AdminGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.AdminGroups == null)
            {
                return Problem("Entity set 'BlogMvcContext.AdminGroups'  is null.");
            }
            var adminGroup = await _context.AdminGroups.FindAsync(id);
            if (adminGroup != null)
            {
                _context.AdminGroups.Remove(adminGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminGroupExists(long id)
        {
          return (_context.AdminGroups?.Any(e => e.GroupNum == id)).GetValueOrDefault();
        }
    }
}
