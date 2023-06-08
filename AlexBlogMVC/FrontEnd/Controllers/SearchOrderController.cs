using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.Areas.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class SearchOrderController : GenericController
    {

        public SearchOrderController(BlogMvcContext context) : base(context) { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            getBanner();
            getNewsType();
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SearchResult(string OrderID)
        {
            OrderViewModel orderViewModel = _context.Orders
                                                .Where(x => x.OrderId == Convert.ToInt64(OrderID))
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
                                                }).FirstOrDefault()!;

            return View(orderViewModel);
        }
    }
}
