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
            List<NewsPageViewModel> newsPage = (from n in _context.News
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
                                                  }).Take(3).ToList();



            List<ShopPageViewModel> shopPage = (from n in _context.Products
                                                where n.ProductPublish == true
                                                orderby n.ProductNum descending
                                                select new ShopPageViewModel
                                                {
                                                    ProductId = n.ProductNum,
                                                    Title = n.ProductTitle,
                                                    Description = n.ProductDescription,
                                                    ProductImg1 = n.ProductImg1,
                                                    CreateTime = n.CreateTime,
                                                    ClassId = n.ProductClass,
                                                    ProductTypeName = (from creator in _context.ProductClasses
                                                                    where creator.ProductClassNum == n.ProductClass
                                                                    select creator.ProductClassName).FirstOrDefault(),
                                                }).Take(6).ToList();


            DefaultViewModel dvm = new DefaultViewModel()
            {
                lstNewsPageViewModel = newsPage,
                lstShopPageViewModel = shopPage
            };

            return View(dvm);
        }
    }
}
