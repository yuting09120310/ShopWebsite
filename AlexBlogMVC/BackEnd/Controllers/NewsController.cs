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

namespace AlexBlogMVC.BackEnd.Controllers
{
    public class NewsController : GenericController
    {
        int menuSubNum = 5;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public NewsController(BlogMvcContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _hostingEnvironment = hostingEnvironment;
        }



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

            ViewBag.PageTitle = "消息列表";

            IEnumerable<NewsViewModel> viewModel = from n in _context.News
                                                    select new NewsViewModel
                                                    {
                                                        NewsNum = n.NewsNum,
                                                        NewsTitle = n.NewsTitle,
                                                        NewsDescription = n.NewsDescription,
                                                        NewsImg1 = n.NewsImg1,
                                                        NewsPutTime = n.NewsPutTime,
                                                        CreateTime = n.CreateTime,
                                                        EditTime = n.EditTime,
                                                        NewsOffTime = n.NewsOffTime,
                                                        NewsPublish = n.NewsPublish
                                                    };

            return View(viewModel);
        }


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

            ViewBag.PageTitle = "新增消息";

            NewsViewModel newsViewModel = new NewsViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")
            };


            //取得分類選單資料
            ViewBag.newsClass = await _context.NewsClasses
                                    .Where(g => g.NewsClassPublish == true)
                                    .Select(g => new SelectListItem { Text = g.NewsClassName, Value = g.NewsClassNum.ToString() })
                                    .ToListAsync();

            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsViewModel newsViewModel)
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
                if (newsViewModel.FileData != null)
                {
                    var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\News");
                    if (!Directory.Exists(direPath))
                    {
                        Directory.CreateDirectory(direPath);
                    }


                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\News", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await newsViewModel.FileData.CopyToAsync(fileStream);
                    }
                }

                News news = new News()
                {
                    NewsClass= newsViewModel.NewsClass,
                    NewsTitle = newsViewModel.NewsTitle,
                    NewsDescription = newsViewModel.NewsDescription,
                    NewsContxt = newsViewModel.NewsContxt,
                    NewsImg1 = fileName,
                    NewsPublish = newsViewModel.NewsPublish,
                    NewsPutTime = newsViewModel.NewsPutTime,
                    NewsOffTime = newsViewModel.NewsOffTime,
                    Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                };

                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(newsViewModel);
        }


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

            ViewBag.PageTitle = "編輯消息";

            if (id == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var newsViewModel = (
                from news in _context.News
                where news.NewsNum == id
                select new NewsViewModel
                {
                    NewsNum = news.NewsNum,
                    NewsTitle = news.NewsTitle,
                    NewsClass = news.NewsClass,
                    NewsDescription = news.NewsDescription,
                    NewsContxt = news.NewsContxt,
                    NewsPublish = news.NewsPublish,
                    NewsPutTime = news.NewsPutTime,
                    NewsOffTime = news.NewsOffTime,
                    CreateTime = news.CreateTime,
                    Creator = news.Creator,
                    CreatorName = (from creator in _context.Admins where creator.AdminNum == news.Creator select creator.AdminName).FirstOrDefault(),
                    EditTime = news.EditTime,
                    Editor = news.Editor,
                    EditorName = (from editor in _context.Admins where editor.AdminNum == news.Editor select editor.AdminName).FirstOrDefault(),
                    Ip = news.Ip,
                    NewsImg1 = news.NewsImg1,
                }
            ).FirstOrDefault();

            if (newsViewModel.NewsImg1 != null)
            {
                newsViewModel.FileData = new FormFile(new MemoryStream(), 0, 0, newsViewModel.NewsImg1.ToString(), newsViewModel.NewsImg1.ToString());
            }


            if (newsViewModel == null)
            {
                return NotFound();
            }


            //取得分類選單資料
            ViewBag.newsClass = await _context.NewsClasses
                                    .Where(g => g.NewsClassPublish == true)
                                    .Select(g => new SelectListItem { Text = g.NewsClassName, Value = g.NewsClassNum.ToString() })
                                    .ToListAsync();

            return View(newsViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsViewModel newsViewModel)
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
                    if (newsViewModel.FileData != null)
                    {
                        var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\News");
                        if (!Directory.Exists(direPath))
                        {
                            Directory.CreateDirectory(direPath);
                        }


                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads\\News", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await newsViewModel.FileData.CopyToAsync(fileStream);
                        }
                    }

                    //將資料寫入db
                    News news = new News()
                    {
                        NewsNum = newsViewModel.NewsNum,
                        NewsTitle = newsViewModel.NewsTitle,
                        NewsClass = newsViewModel.NewsClass,
                        NewsDescription = newsViewModel.NewsDescription,
                        NewsContxt = newsViewModel.NewsContxt,
                        NewsPublish = newsViewModel.NewsPublish,
                        NewsPutTime = newsViewModel.NewsPutTime,
                        NewsOffTime = newsViewModel.NewsOffTime,
                        CreateTime = newsViewModel.CreateTime,
                        Creator = newsViewModel.Creator,
                        EditTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                        Ip = newsViewModel.Ip,
                    };

                    if (newsViewModel.FileData != null)
                    {
                        news.NewsImg1 = fileName;
                    }
                    else
                    {
                        news.NewsImg1 = newsViewModel.NewsImg1;
                    }


                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(newsViewModel.NewsNum))
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
            return View(newsViewModel);
        }


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

            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsNum == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'BlogMvcContext.News'  is null.");
            }
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(long id)
        {
          return (_context.News?.Any(e => e.NewsNum == id)).GetValueOrDefault();
        }
    }
}
