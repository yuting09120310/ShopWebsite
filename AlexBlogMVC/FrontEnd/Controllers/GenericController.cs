using AlexBlogMVC.Areas.Models;
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
            Banner banner = _context.Banners.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            ViewBag.Banner = banner.BannerImg1;
        }

        
    }
}
