using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;

namespace ShopWebsite.Areas.BackEnd.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private ShopWebsiteContext _context;

        public OrderRepository(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public List<OrderIndexViewModel> GetList()
        {
            List<OrderIndexViewModel> viewModel = _context.Orders
                                               .Select(o => new OrderIndexViewModel
                                               {
                                                   OrderID = o.OrderId,
                                                   CustomerName = o.CustomerName,
                                                   Email = o.Email,
                                                   OrderDate = o.OrderDate,
                                                   PaymentMethod = o.PaymentMethod,
                                                   ShippingAddress = o.ShippingAddress,
                                                   TotalAmount = o.TotalAmount,
                                                   OrderStatus = o.OrderStatus
                                               }).ToList();

            return viewModel;
        }


        public OrderEditViewModel Edit(long id)
        {
            OrderEditViewModel viewModel = _context.Orders
                                                .Where(x => x.OrderId == id)
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

            return viewModel;
        }

        
        public void Edit(OrderEditViewModel orderViewModel, long AdminNum)
        {
            Order orders = new Order()
            {
                OrderId = orderViewModel.OrderID,
                CustomerName = orderViewModel.CustomerName,
                Email = orderViewModel.Email,
                OrderDate = orderViewModel.OrderDate,
                PaymentMethod = orderViewModel.PaymentMethod,
                ShippingAddress = orderViewModel.ShippingAddress,
                TotalAmount = orderViewModel.TotalAmount,
                OrderStatus = orderViewModel.OrderStatus
            };

            // 更新訂單
            _context.Orders.Update(orders);
            _context.SaveChanges();
        }


        public string Delete(long id)
        {
            var order = _context.Orders
               .FirstOrDefault(m => m.OrderId == id);

            string result = JsonConvert.SerializeObject(order);

            return result;
        }


        public void DeleteConfirmed(long id)
        {
            // 刪除Order
            Order order = _context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            _context.Orders.Remove(order);

            // 取得符合條件的 OrderProduct
            List<OrderProduct> orderProducts = _context.OrderProducts.Where(x => x.OrderId == id).ToList();

            // 刪除 OrderProduct
            _context.OrderProducts.RemoveRange(orderProducts);

            _context.SaveChanges();
        }


        public void SaveFile(IFormFile file, string path)
        {
            var direPath = Path.Combine(path, "uploads", "News");
            if (!Directory.Exists(direPath))
            {
                Directory.CreateDirectory(direPath);
            }

            var filePath = Path.Combine(direPath, file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
