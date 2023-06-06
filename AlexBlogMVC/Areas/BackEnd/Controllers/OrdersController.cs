using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexBlogMVC.Areas.BackEnd.Models;
using AlexBlogMVC.Areas.Controllers;
using AlexBlogMVC.Areas.ViewModel;

namespace AlexBlogMVC.Areas.BackEnd.Controllers
{
    [Area("BackEnd")]
    public class OrdersController : GenericController
    {
        int menuSubNum = 12;

        public OrdersController(BlogMvcContext context) : base(context) { }


        // GET: BackEnd/Orders
        public async Task<IActionResult> Index()
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "R"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

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


        // GET: BackEnd/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        // GET: BackEnd/Orders/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: BackEnd/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,PaymentMethod,ShippingAddress,TotalAmount,OrderStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: BackEnd/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

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
            #region 登入 權限判斷
            if (!LoginState())
            {
                return View("Error", new List<string> { "401", "尚未登入，請先登入帳號。", "點我登入", "Login", "Index" });
            }
            if (!CheckRole(menuSubNum, "U"))
            {
                return View("Error", new List<string> { "403", "權限不足，請聯繫管理員。", "回首頁", "Home", "Index" });
            }
            GetMenu();
            #endregion

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Orders.Update(orderViewModel.order);

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

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderViewModel);
        }

        // GET: BackEnd/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: BackEnd/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'BlogMvcContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
