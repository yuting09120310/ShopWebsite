using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class ShopPageController : GenericController
    {

        public ShopPageController(BlogMvcContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getBanner();
            getNewsType();
        }


        public IActionResult Index(string ClassType)
        {
            DateTime today = DateTime.Today;

            List<SingleProductViewModel> shopPage = (from n in _context.Products
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
                                                                            select creator.ProductClassName).FirstOrDefault()!,
                                                         Price = n.ProductPrice,
                                                     }).ToList();

            List<ProductClass> productClasses = _context.ProductClasses.Where(x => x.ProductClassPublish == true).ToList();


            ///搜尋條件
            if (ClassType != null)
            {
                shopPage = shopPage.Where(x => x.ClassId == Convert.ToInt64(ClassType)).ToList();
            }


            ShopPageViewModel shopPageViewModel = new ShopPageViewModel()
            {
                ListProductViewModels = shopPage,
                ListproductClass = productClasses
            };

            return View(shopPageViewModel);
        }


        /// <summary>
        /// 商品資訊頁面
        /// </summary>
        /// <param name="Id">商品編號</param>
        /// <returns></returns>
        public IActionResult Detail(long Id)
        {
            SingleProductViewModel shopPage = (from n in _context.Products
                                               where n.ProductNum == Id
                                               select new SingleProductViewModel
                                               {
                                                   ProductId = n.ProductNum,
                                                   Title = n.ProductTitle,
                                                   Description = n.ProductDescription,
                                                   contxt = n.ProductContxt,
                                                   ProductImg1 = n.ProductImg1,
                                                   CreateTime = n.CreateTime,
                                                   ClassId = n.ProductClass,
                                                   ProductTypeName = (from creator in _context.ProductClasses
                                                                      where creator.ProductClassNum == n.ProductClass
                                                                      select creator.ProductClassName).FirstOrDefault(),
                                                   Price = n.ProductPrice,
                                               }).FirstOrDefault()!;

            return View(shopPage);
        }


        
    }
}
