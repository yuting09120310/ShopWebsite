using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.BackEnd.Models;
using AlexBlogMVC.BackEnd.ViewModel;
using AlexBlogMVC.FrontEnd.ViewModel;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class NewsPageController : GenericController
    {

        public NewsPageController(BlogMvcContext context) : base(context) { }


        // GET: News
        public async Task<IActionResult> Index()
        {
            getBanner();

            IEnumerable<NewsPageViewModel> viewModel = from n in _context.News
                                                       where n.NewsPublish == true
                                                       select new NewsPageViewModel
                                                       {
                                                           Id = n.NewsNum,
                                                           Title = n.NewsTitle,
                                                           Description = n.NewsDescription,
                                                           NewsImg1 = n.NewsImg1,
                                                           CreateTime = n.CreateTime,
                                                           NewsType = (from creator in _context.NewsClasses 
                                                                     where creator.NewsClassNum == n.NewsClass 
                                                                     select creator.NewsClassName).FirstOrDefault(),
                                                       };


            return View(viewModel);
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
                    Id = n.NewsNum,
                    Title = n.NewsTitle,
                    Description = n.NewsDescription,
                    NewsImg1 = n.NewsImg1,
                    CreateTime = n.CreateTime,
                    NewsType = (from creator in _context.NewsClasses
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

    }
}
