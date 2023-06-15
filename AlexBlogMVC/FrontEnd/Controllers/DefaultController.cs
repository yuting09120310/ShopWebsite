using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class DefaultController : GenericController
    {

        public DefaultController(BlogMvcContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetNewsType();
        }


        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;

            List<Banner> banner = await (from n in _context.Banners
                                   where n.BannerPublish == true && n.BannerPutTime < today && n.BannerOffTime > today
                                   orderby n.BannerNum descending
                                   select new Banner
                                   {
                                       BannerNum= n.BannerNum,
                                       BannerTitle= n.BannerTitle,
                                       BannerDescription= n.BannerDescription,
                                       BannerImg1= n.BannerImg1,
                                   }
                                   ).ToListAsync();


            List<NewsPageViewModel> newsPage = await (from n in _context.News
                                                  where n.NewsPublish == true && n.NewsPutTime < today && n.NewsOffTime > today
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
                                                                      select creator.NewsClassName).FirstOrDefault()!,
                                                  }).Take(3).ToListAsync();



            List<SingleProductViewModel> shopPage = await (from n in _context.Products
                                                where n.ProductPublish == true && n.ProductPutTime < today && n.ProductOffTime > today
                                                orderby n.ProductNum descending
                                                select new SingleProductViewModel
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
                                                }).Take(6).ToListAsync();


            DefaultViewModel dvm = new DefaultViewModel()
            {
                lstBanner = banner,
                lstNewsPageViewModel = newsPage,
                lstShopPageViewModel = shopPage
            };

            return View(dvm);
        }
    }
}
