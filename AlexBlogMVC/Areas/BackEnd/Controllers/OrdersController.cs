using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.Controllers;
using ShopWebsite.Areas.ViewModel;
using Newtonsoft.Json;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    [Area("BackEnd")]
    public class OrdersController : GenericController
    {
        int menuSubNum = 12;

        public OrdersController(BlogMvcContext context) : base(context) { }


        // GET: BackEnd/Orders
        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<OrderViewModel> orderViewModel = _context.Orders
                                                .Select(o => new OrderViewModel
                                                {
                                                    order = o,
                                                    orderProduct = _context.OrderProducts
                                                    .Where(x => x.OrderId == o.OrderId)
                                                    .Select(op => new OrderProductViewModel
                                                    {
                                                        OrderProductId = op.OrderProductId,
                                                        ProductId = op.ProductId,
                                                        Quantity = op.Quantity,
                                                        Price = op.Price,
                                                        Discount = op.Discount
                                                    }).ToList()
                                                })
                                                .ToList();

            return View(orderViewModel);
        }


        // GET: BackEnd/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            GetMenu();

            OrderViewModel orderViewModel = _context.Orders
                                                .Where(x => x.OrderId == id)
                                                .Select(o => new OrderViewModel
                                                {
                                                    order = o,
                                                    orderProduct = _context.OrderProducts
                                                    .Where(x => x.OrderId == o.OrderId)
                                                    .Select(op => new OrderProductViewModel
                                                    {
                                                        OrderProductId = op.OrderProductId,
                                                        OrderId  = op.OrderId,
                                                        ProductName = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductTitle).FirstOrDefault()!,
                                                        ProductImg = (from product in _context.Products where product.ProductNum == op.ProductId select product.ProductImg1).FirstOrDefault()!,
                                                        ProductId = op.ProductId,
                                                        Quantity = op.Quantity,
                                                        Price = op.Price,
                                                        Discount = op.Discount
                                                    }).ToList()
                                                }).FirstOrDefault()!;

            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }


        // POST: BackEnd/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderViewModel orderViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                try
                {
                    // 更新訂單
                    _context.Orders.Update(orderViewModel.order);

                    // 更新訂單產品
                    foreach (OrderProductViewModel item in orderViewModel.orderProduct)
                    {
                        OrderProduct orderProduct = new OrderProduct()
                        {
                            OrderProductId = item.OrderProductId,
                            OrderId = item.OrderId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            Discount = item.Discount
                        };
                        _context.OrderProducts.Update(orderProduct);
                    }

                    // 儲存變更
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // 處理同時更新衝突的例外錯誤
                    ViewBag.result = "更新資料異常，請聯繫管理員。";
                }

                // 重新導向到 Index 頁面
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // 模型驗證未通過，返回包含 orderViewModel 的 View
                ViewBag.result = "驗證未通過，請聯繫管理員。";
                return View(orderViewModel);
            }

        }


        //詢問視窗
        // GET: BackEnd/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);

            string res =  JsonConvert.SerializeObject(order);

            return Json(res);
        }


        // 確定刪除
        // POST: BackEnd/Orders/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // 刪除Order
            Order order = _context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            _context.Orders.Remove(order);

            // 取得符合條件的 OrderProduct
            List<OrderProduct> orderProducts = _context.OrderProducts.Where(x => x.OrderId == id).ToList();

            // 刪除 OrderProduct
            _context.OrderProducts.RemoveRange(orderProducts);

            await _context.SaveChangesAsync();

            return Json("刪除成功");
        }


        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
