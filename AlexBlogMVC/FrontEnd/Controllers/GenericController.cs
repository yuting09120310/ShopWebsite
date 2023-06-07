using AlexBlogMVC.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class GenericController : Controller
    {
        public readonly BlogMvcContext _context;

        public GenericController(BlogMvcContext context)
        {
            _context = context;
        }


        public void getBanner()
        {
            DateTime today = DateTime.Today;

            Banner banner = _context.Banners
                .Where(x => x.BannerPublish == true && x.BannerPutTime < today && x.BannerOffTime > today)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            ViewBag.Banner = banner.BannerImg1;
        }

        public void getNewsType()
        {
            List<NewsClass> newsClass = _context.NewsClasses.Where(x => x.NewsClassPublish == true).ToList();
            ViewBag.NewsType = newsClass;
        }
    }
}
