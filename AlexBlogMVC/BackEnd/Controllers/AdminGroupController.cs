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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class AdminGroupController : GenericController
    {
        int menuSubNum = 2;

        public AdminGroupController(BlogMvcContext context) : base(context) { }


        // GET: AdminGroup
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

            var admins = await _context.Admins.ToListAsync();
            var adminGroups = await _context.AdminGroups.ToListAsync();

            var viewModel = from g in adminGroups
                            join a1 in admins on g.Creator equals a1.AdminNum into ag1
                            from subg1 in ag1.DefaultIfEmpty()
                            join amenuSubNum in admins on g.Editor equals amenuSubNum.AdminNum into agmenuSubNum
                            from subgmenuSubNum in agmenuSubNum.DefaultIfEmpty()
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
                                EditorName = subgmenuSubNum?.AdminName,
                            };

            return View(viewModel);
        }

        // GET: AdminGroup/Create
        public async Task<IActionResult> Create()
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

            AdminGroupViewModel agv = new AdminGroupViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName"),
                Creator = Convert.ToInt64(HttpContext.Session.GetString("AdminNum")),
                GroupName = "",
                GroupInfo = "",
                GroupPublish = true,

                AdminRoleModels = new List<AdminRole>(),
                MenuGroupModels = await _context.MenuGroups.Where(x => x.MenuGroupPublish == true).ToListAsync(),
                MenuSubModels = await _context.MenuSubs.Where(x => x.MenuSubPublish == true).ToListAsync(),
            };

            return View(agv);
        }

        // POST: AdminGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection Collection)
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


            AdminGroup adminGroup = new AdminGroup()
            {
                GroupPublish = Convert.ToBoolean(Collection["GroupPublish"]),
                GroupName = Collection["GroupName"],
                GroupInfo = Collection["GroupInfo"],
                Creator = Convert.ToInt64(Collection["Creator"]),
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            };

            _context.Add(adminGroup);
            await _context.SaveChangesAsync();

            //取得關於Role開頭的Key 重組成字典 以便於後續操作
            Dictionary<string, string> roleDicts = Collection
             .Where(kv => kv.Key.StartsWith("Role"))
             .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value))
             .ToDictionary(kv => kv.Key, kv => kv.Value);


            //將取出開頭包含Role的字典 跑迴圈 並逐筆變更
            foreach (string roleDict in roleDicts.Keys)
            {
                long menuSubNum = Convert.ToInt64(roleDict);
                AdminRole ar = new AdminRole()
                {
                    GroupNum = adminGroup.GroupNum,
                    MenuSubNum = menuSubNum,
                    Role = roleDicts[roleDict],
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Creator = Convert.ToInt64(HttpContext.Session.GetString("AdminNum")),
                };
                _context.Add(ar);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }


        // GET: AdminGroup/Edit/5
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

            AdminGroup adminGroup = await _context.AdminGroups.FindAsync(id);
            if (adminGroup == null)
            {
                return NotFound();
            }


            AdminGroupViewModel agv = new AdminGroupViewModel()
            {
                GroupName = adminGroup.GroupName,
                GroupInfo = adminGroup.GroupInfo,
                GroupPublish = adminGroup.GroupPublish,
                GroupNum = adminGroup.GroupNum,

                AdminRoleModels = await _context.AdminRoles.Where(x => x.GroupNum == id).ToListAsync(),
                MenuGroupModels = await _context.MenuGroups.Where(x => x.MenuGroupPublish == true).ToListAsync(),
                MenuSubModels = await _context.MenuSubs.Where(x => x.MenuSubPublish == true).ToListAsync(),
            };


            return View(agv);
        }

        // POST: AdminGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, IFormCollection Collection)
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


            //取得變更的群組id
            int groupNum = Convert.ToInt32(Collection["GroupNum"]);


            //取得關於Role開頭的Key 重組成字典 以便於後續操作
            Dictionary<string, string> roleDicts = Collection
             .Where(kv => kv.Key.StartsWith("Role"))
             .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value))
             .ToDictionary(kv => kv.Key, kv => kv.Value);


            //將取出開頭包含Role的字典 跑迴圈 並逐筆變更
            foreach (string roleDict in roleDicts.Keys)
            {
                long menuSubNum = Convert.ToInt64(roleDict);
                AdminRole ar =  await _context.AdminRoles.Where(x => x.GroupNum == groupNum && x.MenuSubNum == menuSubNum).FirstAsync();
                ar.Role = roleDicts[roleDict];
                _context.Update(ar);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Edit");
        }

        // GET: AdminGroup/Delete/5
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
