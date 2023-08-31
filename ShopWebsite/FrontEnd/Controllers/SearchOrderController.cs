using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mail;
using System.Net;

namespace ShopWebsite.FrontEnd.Controllers
{
    public class SearchOrderController : GenericController
    {

        public SearchOrderController(ShopWebsiteContext context) : base(context) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetBanner();
            GetNewsType();
        }


        /// <summary>
        /// 搜尋頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 搜尋結果
        /// </summary>
        /// <param name="OrderID">訂單編號</param>
        /// <returns></returns>
        public IActionResult SearchResult(int OrderID)
        {
            OrderViewModel orderViewModel = _context.Orders
                                                .Where(x => x.OrderId == OrderID)
                                                .Select(o => new OrderViewModel
                                                {
                                                    order = o,
                                                    orderProduct = _context.OrderProducts
                                                    .Where(x => x.OrderId == o.OrderId)
                                                    .Select(op => new OrderProductViewModel
                                                    {
                                                        OrderProductId = op.OrderProductId,
                                                        OrderId = op.OrderId,
                                                        ProductName = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductTitle).FirstOrDefault()!,
                                                        ProductImg = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductImg1).FirstOrDefault()!,
                                                        ProductId = op.ProductId,
                                                        Quantity = op.Quantity,
                                                        Price = op.Price,
                                                        Discount = op.Discount
                                                    }).ToList()
                                                }).FirstOrDefault();

            if(orderViewModel == null)
            {
                TempData["ErrorMessage"] = "查無此訂單資訊";
            }

            return View(orderViewModel);
        }
    }
}
