using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Repository;

namespace ShopWebsite.Areas.Controllers
{
    public class AdminsController : GenericController
    {
        int menuSubNum = 1;

        IAdminRepository _adminRepository;


        public AdminsController(BlogMvcContext context) : base(context){
            _adminRepository = new AdminRepository(_context);
        }


        // GET: Admins
        public IActionResult Index()
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
            GetMenu();
            #endregion

            List<AdminViewModel> viewModel = _adminRepository.GetList();

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
            GetMenu();
            #endregion

            //取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

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
            GetMenu();
            #endregion


            if (ModelState.IsValid)
            {
                _adminRepository.PostCreate(adminViewModel);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                //取得群組選單資料
                ViewBag.adminGroup = _adminRepository.GetAdminGroups();

                return View(adminViewModel);
            }
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
            GetMenu();
            #endregion

            //如果傳進來的id是空的 就返回找不到
            if (id == null)
            {
                return NotFound();
            }

            AdminViewModel adminViewModel = _adminRepository.GetEdit(id);

            //如果搜尋是空的 就返回找不到
            if (adminViewModel == null)
            {
                return NotFound();
            }

            //取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

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
            GetMenu();
            #endregion

            if (ModelState.IsValid)
            {
                adminViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

                _adminRepository.PostEdit(adminViewModel);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(adminViewModel);
            }
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(long id)
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
            GetMenu();
            #endregion

            string res = _adminRepository.Delete(id);

            return Json(res);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _adminRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }


        private bool AdminExists(long id)
        {
            return (_context.Admins?.Any(e => e.AdminNum == id)).GetValueOrDefault();
        }
    }
}
