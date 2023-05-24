using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.Areas.Models;
using AlexBlogMVC.Areas.ViewModel;
using AlexBlogMVC.FrontEnd.ViewModel;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class NewsPageController : GenericController
    {

        public NewsPageController(BlogMvcContext context) : base(context) { }


        // GET: News
        public async Task<IActionResult> Index(string ClassType, string Page)
        {
            int itemsPerPage = 5;

            // 根據 ClassType 過濾資料
            IQueryable<NewsPageViewModel> query = from n in _context.News
                                                  where n.NewsPublish == true
                                                  orderby n.NewsNum descending
                                                  select new NewsPageViewModel
                                                  {
                                                      NewsId = n.NewsNum,
                                                      Title = n.NewsTitle,
                                                      Description = n.NewsDescription,
                                                      NewsImg1 = n.NewsImg1,
                                                      CreateTime = n.CreateTime,
                                                      ClassId = n.NewsClass,
                                                      NewsTypeName = (from creator in _context.NewsClasses
                                                                      where creator.NewsClassNum == n.NewsClass
                                                                      select creator.NewsClassName).FirstOrDefault(),
                                                  };

            if (!string.IsNullOrEmpty(ClassType) && Convert.ToInt64(ClassType) != 0)
            {
                query = query.Where(x => x.ClassId == Convert.ToInt64(ClassType));
            }


            // 計算總頁數
            int totalPages = (int)Math.Ceiling((double)query.Count() / itemsPerPage);

            // 根據 Page 參數進行分頁
            int currentPage = string.IsNullOrEmpty(Page) ? 1 : Convert.ToInt32(Page);
            query = query.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);

            // 傳遞資料到檢視
            ViewBag.ClassType = ClassType;
            ViewBag.Page = currentPage;
            ViewBag.TotalPages = totalPages;

            return View(await query.ToListAsync());
        }


        // GET: News/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            getBanner();

            if (id == null || _context.News == null)
            {
                return NotFound();
            }


            //進入DB搜尋資料
            var newsViewModel = (
                from n in _context.News
                where n.NewsNum == id && n.NewsPublish == true
                select new NewsPageViewModel
                {
                    NewsId = n.NewsNum,
                    Title = n.NewsTitle,
                    Description = n.NewsDescription,
                    NewsImg1 = n.NewsImg1,
                    CreateTime = n.CreateTime,
                    NewsTypeName = (from creator in _context.NewsClasses
                                where creator.NewsClassNum == n.NewsClass
                                select creator.NewsClassName).FirstOrDefault(),
                    contxt = n.NewsContxt,
                }
            ).FirstOrDefault();


            if (newsViewModel == null)
            {
                return NotFound();
            }

            return View(newsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Comments(NewsPageViewModel newsPageViewModel)
        {
            

            return RedirectToAction(nameof(Index));
        }
    }
}
