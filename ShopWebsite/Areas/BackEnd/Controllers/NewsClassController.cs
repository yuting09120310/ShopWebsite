using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;

namespace ShopWebsite.Areas.Controllers
{
    public class NewsClassController : GenericController
    {
        INewsClassRepository _newsClassRepository;

        public NewsClassController(ShopWebsiteContext context) : base(context)
        {
            _newsClassRepository = new NewsClassRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<NewsClassIndexViewModel> viewModel = _newsClassRepository.GetList();

            return View(viewModel);
        }


        public IActionResult Create()
        {
            GetMenu();

            NewsClassCreateViewModel newsClassViewModel = _newsClassRepository.Create();

            return View(newsClassViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsClassCreateViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _newsClassRepository.Create(newsClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(newsClassViewModel);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            NewsClassEditViewModel newsClassViewModel = _newsClassRepository.Edit(id);

            return View(newsClassViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsClassEditViewModel newsClassViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _newsClassRepository.Edit(newsClassViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(newsClassViewModel);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _newsClassRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _newsClassRepository.DeleteConfirmed(id);

            return Json("刪除完成");
        }


        private bool NewsClassExists(long id)
        {
          return (_context.NewsClasses?.Any(e => e.NewsClassNum == id)).GetValueOrDefault();
        }
    }
}
