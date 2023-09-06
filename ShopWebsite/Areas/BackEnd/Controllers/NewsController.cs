using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;

namespace ShopWebsite.Areas.Controllers
{
    public class NewsController : GenericController
    {
        INewsRepository _newsRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;


        public NewsController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
            _newsRepository = new NewsRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<NewsIndexViewModel> viewModel = _newsRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();

            NewsCreateViewModel newsViewModel = _newsRepository.Create();

            //取得分類選單資料
            ViewBag.newsClass = _newsRepository.GetNewsClasseList();

            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCreateViewModel newsViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _newsRepository.SaveFile(newsViewModel.NewsImg1, _hostingEnvironment.WebRootPath);

                _newsRepository.Create(newsViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));
                
                return RedirectToAction(nameof(Index));
            }

            return View(newsViewModel);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            if (id == null)
            {
                return NotFound();
            }


            NewsEditViewModel newsViewModel = _newsRepository.Edit(id);



            if (newsViewModel == null)
            {
                return NotFound();
            }


            //取得分類選單資料
            ViewBag.newsClass = _newsRepository.GetNewsClasseList();

            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsEditViewModel newsViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (newsViewModel.NewsImg1 != null)
                {
                    _newsRepository.SaveFile(newsViewModel.NewsImg1, _hostingEnvironment.WebRootPath);
                }

                _newsRepository.Edit(newsViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }
            return View(newsViewModel);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _newsRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _newsRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }

        private bool NewsExists(long id)
        {
          return (_context.News?.Any(e => e.NewsNum == id)).GetValueOrDefault();
        }
    }
}
