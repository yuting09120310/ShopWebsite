using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Mail;
using System.Net;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;

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
            OrderEditViewModel orderViewModel = _context.Orders
                                                .Where(x => x.OrderId == OrderID)
                                                .Select(o => new OrderEditViewModel
                                                {
                                                    OrderID = o.OrderId,
                                                    CustomerName = o.CustomerName,
                                                    Email = o.Email,
                                                    OrderDate = o.OrderDate,
                                                    PaymentMethod = o.PaymentMethod,
                                                    ShippingAddress = o.ShippingAddress,
                                                    TotalAmount = o.TotalAmount,
                                                    OrderStatus = o.OrderStatus,

                                                    orderProductViewModels = _context.OrderProducts
                                                    .Where(x => x.OrderId == o.OrderId)
                                                    .Select(op => new OrderProductViewModel
                                                    {
                                                        ProductName = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductTitle).FirstOrDefault()!,
                                                        ProductImg = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductImg1).FirstOrDefault()!,
                                                        Quantity = op.Quantity,
                                                        Price = op.Price,
                                                    }).ToList()
                                                }).FirstOrDefault()!;

            if (orderViewModel == null)
            {
                TempData["ErrorMessage"] = "查無此訂單資訊";
            }

            return View(orderViewModel);
        }
    }
}
