using AlexBlogMVC.BackEnd.Attributes;
using AlexBlogMVC.BackEnd.Models;
using AlexBlogMVC.BackEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class AdminsController : GenericController
    {
        int menuSubNum = 1;

        public AdminsController(BlogMvcContext context) : base(context){}


        // GET: Admins
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

            IEnumerable<AdminViewModel> viewModel = from a in admins
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

            //取得群組選單資料
            ViewBag.adminGroup = await _context.AdminGroups
                                    .Where(g => g.GroupPublish == true)
                                    .Select(g => new SelectListItem { Text = g.GroupName, Value = g.GroupNum.ToString() })
                                    .ToListAsync();

            AdminViewModel viewModel = new AdminViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };

            return View(viewModel);
        }


        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=3menuSubNum7598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminNum,GroupNum,AdminAcc,AdminPwd,AdminName,AdminPublish,Creator")] AdminViewModel adminViewModel)
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
                Admin admin = new Admin()
                {
                    AdminNum = adminViewModel.AdminNum,
                    GroupNum = adminViewModel.GroupNum,
                    AdminAcc = adminViewModel.AdminAcc,
                    AdminPwd = adminViewModel.AdminPwd,
                    AdminName = adminViewModel.AdminName,
                    AdminPublish = adminViewModel.AdminPublish,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                };

                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //取得群組選單資料
            ViewBag.adminGroup = await _context.AdminGroups
                                    .Where(g => g.GroupPublish == true)
                                    .Select(g => new SelectListItem { Text = g.GroupName, Value = g.GroupNum.ToString() })
                                    .ToListAsync();

            return View(adminViewModel);
        }


        // GET: Admins/Edit/5
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


            //如果傳進來的id是空的 就返回找不到
            if (id == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var adminViewModel = (
                from admins in _context.Admins
                join adminGroup in _context.AdminGroups on admins.GroupNum equals adminGroup.GroupNum into adminGroups
                from adminGroup in adminGroups.DefaultIfEmpty()
                where admins.AdminNum == id
                select new AdminViewModel
                {
                    AdminNum = admins.AdminNum,
                    GroupName = adminGroup.GroupName,
                    AdminAcc = admins.AdminAcc,
                    AdminPwd = null,
                    AdminName = admins.AdminName,
                    AdminPublish = admins.AdminPublish,
                    LastLogin = admins.LastLogin,
                    CreateTime = admins.CreateTime,
                    Creator = admins.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == admins.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = admins.EditTime,
                    Editor = admins.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == admins.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = admins.Ip,
                    GroupNum = admins.GroupNum
                }
            ).FirstOrDefault();

            //如果搜尋是空的 就返回找不到
            if (adminViewModel == null)
            {
                return NotFound();
            }

            //取得群組選單資料
            ViewBag.adminGroup = await _context.AdminGroups
                                    .Where(g => g.GroupPublish == true)
                                    .Select(g => new SelectListItem { Text = g.GroupName, Value = g.GroupNum.ToString() })
                                    .ToListAsync();

            return View(adminViewModel);
        }


        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=3menuSubNum7598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("AdminNum,GroupNum,AdminAcc,AdminPwd,AdminName,AdminPublish,LastLogin,CreateTime,Creator,EditTime,Editor,Ip")] AdminViewModel adminViewModel)
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

            if (ModelState.IsValid)
            {
                try
                {
                    adminViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));
                    adminViewModel.EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    Admin admin = new Admin()
                    {
                        AdminNum = adminViewModel.AdminNum,
                        GroupNum = adminViewModel.GroupNum,
                        AdminAcc = adminViewModel.AdminAcc,
                        AdminPwd= adminViewModel.AdminPwd,
                        AdminName= adminViewModel.AdminName,
                        LastLogin = adminViewModel.LastLogin,
                        AdminPublish =adminViewModel.AdminPublish,
                        CreateTime= adminViewModel.CreateTime,
                        Creator= adminViewModel.Creator,
                        EditTime= adminViewModel.EditTime,
                        Editor= adminViewModel.Editor,
                        Ip= adminViewModel.Ip,
                    };

                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(adminViewModel.AdminNum))
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
            return View(adminViewModel);
        }

        // GET: Admins/Delete/5
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
