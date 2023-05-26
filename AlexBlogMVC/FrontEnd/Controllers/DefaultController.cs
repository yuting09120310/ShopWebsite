using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class DefaultController : GenericController
    {

        public DefaultController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            // 根據 ClassType 過濾資料˙
            IQueryable<NewsPageViewModel> query = (from n in _context.News
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
                                                  }).Take(5);


            return View();
        }
    }
}
