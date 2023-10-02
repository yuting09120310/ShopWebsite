using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;
using ShopWebsite.Areas.Controllers;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    [Area("BackEnd")]
    public class OrdersController : GenericController
    {
        IOrderRepository _orderRepository;

        public OrdersController(ShopWebsiteContext context) : base(context) 
        {
            _orderRepository = new OrderRepository(context);
        }


        // GET: BackEnd/Orders
        public async Task<IActionResult> Index()
        {
            GetMenu();

            List<OrderIndexViewModel> orderViewModel = _orderRepository.GetList();

            return View(orderViewModel);
        }


        // GET: BackEnd/Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            GetMenu();

            OrderEditViewModel orderViewModel = _orderRepository.Edit(id);

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
        public async Task<IActionResult> Edit(OrderEditViewModel orderViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                _orderRepository.Edit(orderViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(orderViewModel);
        }


        //詢問視窗
        // GET: BackEnd/Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string res =  _orderRepository.Delete(id);

            return Json(res);
        }


        // 確定刪除
        // POST: BackEnd/Orders/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _orderRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }


        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
