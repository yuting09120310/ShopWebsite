﻿using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class DefaultController : GenericController
    {

        public DefaultController(BlogMvcContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getNewsType();
        }


        public IActionResult Index()
        {
            List<Banner> banner = (from n in _context.Banners
                                   where n.BannerPublish == true
                                   orderby n.BannerNum descending
                                   select new Banner
                                   {
                                       BannerNum= n.BannerNum,
                                       BannerTitle= n.BannerTitle,
                                       BannerDescription= n.BannerDescription,
                                       BannerImg1= n.BannerImg1,
                                   }
                                   ).ToList();


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



            List<SingleProductViewModel> shopPage = (from n in _context.Products
                                                where n.ProductPublish == true
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
                                                }).Take(6).ToList();


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