using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;

namespace ShopWebsite.Areas.Controllers
{
    public class BannerController : GenericController
    {
        IBannerRepository _bannerRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public BannerController(ShopWebsiteContext context, IWebHostEnvironment hostingEnvironment) :base(context){
            _hostingEnvironment = hostingEnvironment;
            _bannerRepository = new BannerRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            GetMenu();
          
            List<BannerIndexViewModel> viewModel = _bannerRepository.GetList();

            return View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            GetMenu();

            ViewBag.PageTitle = "新增廣告";

            BannerCreateViewModel viewModel = _bannerRepository.Create();

            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerCreateViewModel bannerViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _bannerRepository.SaveFile(bannerViewModel.BannerImg1, _hostingEnvironment.WebRootPath);

                _bannerRepository.Create(bannerViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));
                
                return RedirectToAction(nameof(Index));
            }

            return View(bannerViewModel);
        }

        // GET: Banner/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            GetMenu();

            ViewBag.PageTitle = "編輯廣告";

            if (id == null)
            {
                return NotFound();
            }

            BannerEditViewModel bannerViewModel = _bannerRepository.Edit(id);

            if (bannerViewModel == null)
            {
                return NotFound();
            }

            return View(bannerViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerEditViewModel bannerViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                if (bannerViewModel.BannerImg1 != null)
                {
                    _bannerRepository.SaveFile(bannerViewModel.BannerImg1, _hostingEnvironment.WebRootPath);
                }

                _bannerRepository.Edit(bannerViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(bannerViewModel);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            GetMenu();

            string result = _bannerRepository.Delete(id);

            return Json(result);
        }


        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _bannerRepository.DeleteConfirmed(id, _hostingEnvironment.WebRootPath);

            return Json("刪除完成");
        }

        private bool BannerExists(long id)
        {
          return (_context.Banners?.Any(e => e.BannerNum == id)).GetValueOrDefault();
        }
    }
}
