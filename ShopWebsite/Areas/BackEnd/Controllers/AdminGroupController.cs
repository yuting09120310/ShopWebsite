using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.ViewModel;
using System.Data;

namespace ShopWebsite.Areas.Controllers
{

    public class AdminGroupController : GenericController
    {
        IAdminGroupRepository _adminGroupRepository;


        public AdminGroupController(ShopWebsiteContext context) : base(context) {
            _adminGroupRepository = new AdminGroupRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<AdminGroupViewModel> viewModel = _adminGroupRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();

            AdminGroupViewModel adminGroupViewModel = _adminGroupRepository.Create();

            return View(adminGroupViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection Collection)
        {
            GetMenu();

            long AdminNum = Convert.ToInt64(HttpContext.Session.GetString("AdminNum"));

            _adminGroupRepository.Create(Collection, AdminNum);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            AdminGroupViewModel adminGroupViewModel = _adminGroupRepository.Edit(id);

            return View(adminGroupViewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection Collection)
        {
            GetMenu();

            long AdminNum = Convert.ToInt64(HttpContext.Session.GetString("AdminNum"));

            _adminGroupRepository.Edit(Collection, AdminNum);

            return RedirectToAction("Index");
        }


        // GET: AdminGroup/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _adminGroupRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _adminGroupRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }

        private bool AdminGroupExists(long id)
        {
          return (_context.AdminGroups?.Any(e => e.GroupNum == id)).GetValueOrDefault();
        }
    }
}
