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
            return RedirectToAction("Cart", "ShopPage");
        }


        /// <summary>
        /// 購物車頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Cart()
        {
            var sessionKeys = HttpContext.Session.Keys;

            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.singleProductViewModels = new List<SingleProductViewModel>();

            foreach (var productId in sessionKeys)
            {
                SingleProductViewModel cart = (from n in _context.Products
                                               where n.ProductNum == Convert.ToInt64(productId)
                                               select new SingleProductViewModel
                                               {
                                                   ProductId = n.ProductNum,
                                                   Title = n.ProductTitle,
                                                   Price = n.ProductPrice,
                                                   amount = Convert.ToInt16(HttpContext.Session.GetString(productId)),
                                                   ProductImg1 = n.ProductImg1
                                               }).FirstOrDefault();

                cartViewModel.singleProductViewModels.Add(cart);

                cartViewModel.Total += cart.Price * cart.amount;
            }

            return View(cartViewModel);
        }


        /// <summary>
        /// 購物車頁面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cart(CartViewModel cartViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.result = "下單失敗，請確認填寫內容是否正確!!";
                if(cartViewModel.singleProductViewModels == null)
                {
                    cartViewModel.singleProductViewModels = new List<SingleProductViewModel>();
                }

                return View(cartViewModel);
            }

            Order order = new Order()
            {
                CustomerName = cartViewModel.Name,
                OrderDate = DateTime.Now,
                PaymentMethod = "貨到付款",
                ShippingAddress = cartViewModel.Address,
                TotalAmount = cartViewModel.Total,
                OrderStatus = "揀貨中"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach(SingleProductViewModel item in cartViewModel.singleProductViewModels)
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


            cartViewModel.Name = string.Empty;
            cartViewModel.Phone = string.Empty;
            cartViewModel.Address = string.Empty;
            cartViewModel.Total = 0;
            cartViewModel.singleProductViewModels.Clear();


            return View(cartViewModel);
        }
    }
}
