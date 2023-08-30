﻿using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

namespace ShopWebsite.Areas.Controllers
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
            GetMenu();

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
            GetMenu();

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
            GetMenu();

            if (ModelState.IsValid)
            {
                string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                //接收檔案
                if (newsViewModel.FileData != null)
                {
                    var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");
                    if (!Directory.Exists(direPath))
                    {
                        Directory.CreateDirectory(direPath);
                    }


                    var filePath = Path.Combine(direPath, fileName);
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
                    Tag = newsViewModel.Tag
                };

                _context.Add(news);
                await _context.SaveChangesAsync();
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
                    Tag = news.Tag
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
            GetMenu();

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffff") + ".jpg";

                    //接收檔案
                    if (newsViewModel.FileData != null)
                    {
                        var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");

                        if (!Directory.Exists(direPath))
                        {
                            Directory.CreateDirectory(direPath);
                        }


                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/News", fileName);
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
                        Tag = newsViewModel.Tag
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
            GetMenu();

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsNum == id);

            string res = JsonConvert.SerializeObject(news);

            return Json(res);
        }


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

            //取得該篇文章的圖片並刪除
            var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");
            var filePath = Path.Combine(direPath, news.NewsImg1);
            System.IO.File.Delete(filePath);

            return Json("刪除完成");
        }

        private bool NewsExists(long id)
        {
          return (_context.News?.Any(e => e.NewsNum == id)).GetValueOrDefault();
        }
    }
}