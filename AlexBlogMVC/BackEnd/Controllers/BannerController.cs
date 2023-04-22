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
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BannerController(BlogMvcContext context, IWebHostEnvironment hostingEnvironment) :base(context){
            _hostingEnvironment = hostingEnvironment;
        }


        //當每個action被執行都會呼叫getMenu
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }


        // GET: Banner
        public async Task<IActionResult> Index()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(3, "R"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

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
        public IActionResult Create()
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(3, "C"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();


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
        public async Task<IActionResult> Create([Bind("BannerNum,Lang,ProductClass,BannerSort,BannerTitle,BannerDescription,BannerContxt,BannerImg1,BannerImgUrl,BannerImgAlt,BannerPublish,BannerPutTime,CreateTime,Creator,EditTime,Editor,Ip,BannerOffTime,FileData")] BannerViewModel bannerViewModel, IFormFile FileData)
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(3, "C"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();

            if (ModelState.IsValid)
            {
                
                //接收檔案
                if (bannerViewModel.FileData != null)
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", bannerViewModel.FileData.FileName);
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
                    BannerImg1 = bannerViewModel.FileData.FileName
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
            if (id == null)
            {
                return NotFound();
            }

            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(3, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();


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
        public async Task<IActionResult> Edit([Bind("BannerNum,Lang,ProductClass,BannerSort,BannerTitle,BannerDescription,BannerContxt,BannerImg1,BannerImgUrl,BannerImgAlt,BannerPublish,BannerPutTime,CreateTime,Creator,EditTime,Editor,Ip,BannerOffTime,FileData")] BannerViewModel bannerViewModel)
        {
            if (!LoginState())
            {
                return StatusCode(403, "還沒登入喔");
            }
            if (!CheckRole(3, "U"))
            {
                return StatusCode(403, "當前用戶沒有權限");
            }
            getMenu();


            if (ModelState.IsValid)
            {
                try
                {
                    //接收檔案
                    if (bannerViewModel.FileData != null)
                    {
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", bannerViewModel.FileData.FileName);
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
                        banner.BannerImg1 = bannerViewModel.FileData.FileName;
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
