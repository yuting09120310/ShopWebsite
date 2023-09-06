using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel;

namespace ShopWebsite.Areas.Controllers
{
    public class AdminsController : GenericController
    {

        IAdminRepository _adminRepository;


        public AdminsController(ShopWebsiteContext context) : base(context){
            _adminRepository = new AdminRepository(_context);
        }


        public IActionResult Index()
        {
            GetMenu();

            List<AdminIndexViewModel> viewModel = _adminRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();
            
            //取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

            AdminCreateViewModel viewModel = _adminRepository.Create();

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateViewModel adminViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _adminRepository.Create(adminViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

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
            GetMenu();

            //如果傳進來的id是空的 就返回找不到
            if (id == null)
            {
                return NotFound();
            }

            AdminEditViewModel adminViewModel = _adminRepository.Edit(id);

            //如果搜尋是空的 就返回找不到
            if (adminViewModel == null)
            {
                return NotFound();
            }

            //取得群組選單資料
            ViewBag.adminGroup = _adminRepository.GetAdminGroups();

            return View(adminViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminEditViewModel adminViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _adminRepository.Edit(adminViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(adminViewModel);
            }
        }


        public async Task<IActionResult> Delete(long id)
        {
            GetMenu();

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
