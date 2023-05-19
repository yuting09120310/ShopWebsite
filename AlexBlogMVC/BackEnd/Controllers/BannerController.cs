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
using Microsoft.Extensions.Hosting;

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class BannerController : GenericController
    {
        int menuSubNum = 4;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public BannerController(BlogMvcContext context, IWebHostEnvironment hostingEnvironment) :base(context){
            _hostingEnvironment = hostingEnvironment;
        }


       


        // GET: Banner
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

            ViewBag.PageTitle = "廣告列表";

            IEnumerable<BannerViewModel> viewModel = from a in _context.Banners
                                                    select new BannerViewModel
                                                    {
                                                        BannerNum = a.BannerNum,
                                                        BannerTitle = a.BannerTitle,
                                                        BannerDescription = a.BannerDescription,
                                                        BannerPutTime = a.BannerPutTime,
                                                        BannerImg1= a.BannerImg1,
                                                        CreateTime = a.CreateTime,
                                                        EditTime = a.EditTime,
                                                        BannerOffTime = a.BannerOffTime,
                                                        BannerPublish = a.BannerPublish
                                                    };

            return View(viewModel);
        }


        // GET: Banner/Create
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

            ViewBag.PageTitle = "新增廣告";

            BannerViewModel viewModel = new BannerViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };


            return View(viewModel);
        }

        // POST: Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BannerNum,Lang,ProductClass,BannerSort,BannerTitle,BannerDescription,BannerContxt,BannerImg1,BannerImgUrl,BannerImgAlt,BannerPublish,BannerPutTime,CreateTime,Creator,EditTime,Editor,Ip,BannerOffTime,FileData")] BannerViewModel bannerViewModel)
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
                string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                //接收檔案
                if (bannerViewModel.FileData != null)
                {
                    var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Banner");
                    if (!Directory.Exists(direPath))
                    {
                        Directory.CreateDirectory(direPath);
                    }

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Banner", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await bannerViewModel.FileData.CopyToAsync(fileStream);
                    }
                }

                Banner banner = new Banner()
                {
                    BannerTitle = bannerViewModel.BannerTitle,
                    BannerDescription = bannerViewModel.BannerDescription,
                    BannerContxt = bannerViewModel.BannerContxt,
                    BannerPublish = bannerViewModel.BannerPublish,
                    BannerPutTime = bannerViewModel.BannerPutTime,
                    BannerOffTime = bannerViewModel.BannerOffTime,
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    BannerImg1 = fileName
                };

                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bannerViewModel);
        }

        // GET: Banner/Edit/5
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

            ViewBag.PageTitle = "編輯廣告";

            if (id == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var bannerViewModel = (
                from banner in _context.Banners
                where banner.BannerNum == id
                select new BannerViewModel
                {
                    BannerNum = banner.BannerNum,
                    BannerTitle = banner.BannerTitle,
                    BannerDescription = banner.BannerDescription,
                    BannerContxt = banner.BannerContxt,
                    BannerPublish = banner.BannerPublish,
                    BannerPutTime= banner.BannerPutTime,
                    BannerOffTime = banner.BannerOffTime,
                    CreateTime = banner.CreateTime,
                    Creator = banner.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == banner.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = banner.EditTime,
                    Editor = banner.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == banner.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = banner.Ip,
                    BannerImg1 = banner.BannerImg1,
                }
            ).FirstOrDefault();

            if (bannerViewModel.BannerImg1 != null)
            {
                bannerViewModel.FileData = new FormFile(new MemoryStream(), 0, 0, bannerViewModel.BannerImg1.ToString(), bannerViewModel.BannerImg1.ToString());
            }


            if (bannerViewModel == null)
            {
                return NotFound();
            }


            return View(bannerViewModel);
        }

        // POST: Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerViewModel bannerViewModel)
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

                    string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                    //接收檔案
                    if (bannerViewModel.FileData != null)
                    {
                        var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Banner");
                        if (!Directory.Exists(direPath))
                        {
                            Directory.CreateDirectory(direPath);
                        }

                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\Banner", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await bannerViewModel.FileData.CopyToAsync(fileStream);
                        }
                    }

                    //將資料寫入db
                    Banner banner = new Banner()
                    {
                        BannerNum= bannerViewModel.BannerNum,
                        BannerTitle = bannerViewModel.BannerTitle,
                        BannerDescription = bannerViewModel.BannerDescription,
                        BannerContxt = bannerViewModel.BannerContxt,
                        BannerPublish = bannerViewModel.BannerPublish,
                        BannerPutTime = bannerViewModel.BannerPutTime,
                        BannerOffTime = bannerViewModel.BannerOffTime,
                        CreateTime = bannerViewModel.CreateTime,
                        Creator = bannerViewModel.Creator,
                        EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                        Ip = bannerViewModel.Ip,
                    };

                    if (bannerViewModel.FileData != null)
                    {
                        banner.BannerImg1 = fileName;
                    }
                    else
                    {
                        banner.BannerImg1 = bannerViewModel.BannerImg1;
                    }


                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(bannerViewModel.BannerNum))
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
            return View(bannerViewModel);
        }

        // GET: Banner/Delete/5
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


            if (id == null || _context.Banners == null)
            {
                return NotFound();
            }

            var banner = await _context.Banners
                .FirstOrDefaultAsync(m => m.BannerNum == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Banners == null)
            {
                return Problem("Entity set 'BlogMvcContext.Banners'  is null.");
            }
            var banner = await _context.Banners.FindAsync(id);
            if (banner != null)
            {
                _context.Banners.Remove(banner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(long id)
        {
          return (_context.Banners?.Any(e => e.BannerNum == id)).GetValueOrDefault();
        }
    }
}
