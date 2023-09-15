using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ShopWebsite.FrontEnd.Controllers
{
    public class ShopPageController : GenericController
    {

        public ShopPageController(ShopWebsiteContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetBanner();
            GetNewsType();
        }


        public IActionResult Index(string ClassType, string Page, string searchValue)
        {
            DateTime today = DateTime.Today;

            int itemsPerPage = 6;

            IQueryable<SingleProductViewModel> shopPage = from n in _context.Products
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
                                                         tag = n.Tag
                                                     };

            List<ProductClass> productClasses = _context.ProductClasses.Where(x => x.ProductClassPublish == true).ToList();


            // 取得最多訂單的 ProductId
            List<long> topProductIds = _context.OrderProducts
                                        .GroupBy(p => p.ProductId)
                                        .OrderByDescending(g => g.Count())
                                        .Take(3)
                                        .Select(g => g.Key)
                                        .ToList();

            // 將搜尋出來的結果 去取產品
            var topProducts = _context.Products
                                .Where(p => topProductIds.Contains(Convert.ToInt32(p.ProductNum)))
                                .Select(n => new SingleProductViewModel
                                {
                                    ProductId = n.ProductNum,
                                    Title = n.ProductTitle,
                                    Description = n.ProductDescription,
                                    ProductImg1 = n.ProductImg1,
                                    CreateTime = n.CreateTime,
                                    ClassId = n.ProductClass,
                                    ProductTypeName = _context.ProductClasses
                                        .Where(creator => creator.ProductClassNum == n.ProductClass)
                                        .Select(creator => creator.ProductClassName)
                                        .FirstOrDefault()!,
                                    Price = n.ProductPrice
                                })
                                .ToList();





            //搜尋條件
            if (string.IsNullOrEmpty(ClassType) || ClassType == "0")
            {
                ClassType = "0";
            }
            else
            {
                shopPage = shopPage.Where(x => x.ClassId == Convert.ToInt64(ClassType));
            }


            // 如果有搜尋條件
            if (!string.IsNullOrEmpty(searchValue))
            {
                shopPage = shopPage.Where(x => x.tag.Contains(searchValue));
            }


            // 計算總頁數
            int totalPages = (int)Math.Ceiling((double)shopPage.Count() / itemsPerPage);

            // 根據 Page 參數進行分頁
            int currentPage = string.IsNullOrEmpty(Page) ? 1 : Convert.ToInt32(Page);
            shopPage = shopPage.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);


            // 傳遞資料到檢視
            ViewBag.ClassType = ClassType;
            ViewBag.Page = currentPage;
            ViewBag.TotalPages = totalPages;


            ShopPageViewModel shopPageViewModel = new ShopPageViewModel()
            {
                ListProductViewModels = shopPage.ToList(),
                ListproductClass = productClasses,
                TopProducts = topProducts
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
                                                   tag = n.Tag
                                               }).FirstOrDefault()!;

            return View(shopPage);
        }


        
    }
}
