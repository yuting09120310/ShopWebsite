using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.FrontEnd.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class CartController : GenericController
    {
        /// <summary>
        /// CartController 的建構函式。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public CartController(BlogMvcContext context) : base(context) { }


        /// <summary>
        /// 在動作執行之前執行的方法。
        /// </summary>
        /// <param name="context">資料庫操作的環境。</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetBanner();
            GetNewsType();
        }


        /// <summary>
        /// 加入購物車
        /// </summary>
        /// <param name="Id">商品編號</param>
        /// <param name="amount">數量</param>
        /// <returns></returns>
        public IActionResult AddCart(string Id, string amount)
        {
            HttpContext.Session.SetString(Id, amount);
            return RedirectToAction("Index", "ShopPage");
        }


        /// <summary>
        /// 刪除購物車
        /// </summary>
        /// <param name="Id">商品編號</param>
        /// <returns></returns>
        public IActionResult DelCart(string Id)
        {
            HttpContext.Session.Remove(Id);
            return RedirectToAction("Cart");
        }


        /// <summary>
        /// 購物車頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var sessionKeys = HttpContext.Session.Keys;

            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.singleProductViewModels = new List<SingleProductViewModel>();

            foreach (var productIdString in sessionKeys)
            {
                if (int.TryParse(productIdString, out int productId))
                {
                    SingleProductViewModel cart = (from n in _context.Products
                                                   where n.ProductNum == Convert.ToInt64(productId)
                                                   select new SingleProductViewModel
                                                   {
                                                       ProductId = n.ProductNum,
                                                       Title = n.ProductTitle,
                                                       Price = n.ProductPrice,
                                                       amount = Convert.ToInt16(HttpContext.Session.GetString(productIdString)),
                                                       ProductImg1 = n.ProductImg1,
                                                       tag= n.Tag
                                                   }).FirstOrDefault()!;

                    cartViewModel.singleProductViewModels.Add(cart);

                    cartViewModel.Total += cart.Price * cart.amount;
                }
            }


            return View(cartViewModel);
        }


        /// <summary>
        /// 購物車頁面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(CartViewModel cartViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.result = "下單失敗，請確認填寫內容是否正確!!";
                cartViewModel.singleProductViewModels ??= new List<SingleProductViewModel>();

                return View(cartViewModel);
            }

            Order order = new Order()
            {
                CustomerName = cartViewModel.Name,
                Email = cartViewModel.EMail,
                OrderDate = DateTime.Now,
                PaymentMethod = "貨到付款",
                ShippingAddress = cartViewModel.Address,
                TotalAmount = cartViewModel.Total,
                OrderStatus = "確認中"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach (SingleProductViewModel item in cartViewModel.singleProductViewModels)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderId = order.OrderId,
                    ProductId = (int)item.ProductId,
                    Quantity = item.amount,
                    Price = item.Price,
                };
                _context.OrderProducts.Add(orderProduct);
            }

            _context.SaveChanges();

            HttpContext.Session.Clear();
            ViewBag.result = "下訂成功!!";


            StringBuilder emailContent = new StringBuilder();

            emailContent.AppendLine(@"
親愛的客戶，

感謝您的訂單！我們很高興通知您，您的訂單已經成功處理並準備出貨。

訂單詳細資訊：
訂單編號：" + order.OrderId + @"
下單日期：" + order.OrderDate + @"
付款方式：" + order.PaymentMethod + @"
運送地址：" + order.ShippingAddress + @"

以下是您所訂購的商品：");
            foreach (var item in cartViewModel.singleProductViewModels)
            {
                emailContent.AppendLine(item.Title);
            }

            emailContent.AppendLine(@"

如果您需要追蹤訂單或有任何問題，請聯繫我們的客戶服務部門。我們將竭誠為您提供協助。

再次感謝您的購買，期待與您保持良好的合作關係。

祝您有美好的一天！

AlexBlogMVC");

            
            SendMail(cartViewModel.EMail, "AlexBlog 訂單成功", emailContent.ToString());



            cartViewModel.Name = string.Empty;
            cartViewModel.EMail = string.Empty;
            cartViewModel.Address = string.Empty;
            cartViewModel.Total = 0;
            cartViewModel.singleProductViewModels.Clear();


            return View(cartViewModel);
        }
    }
}
