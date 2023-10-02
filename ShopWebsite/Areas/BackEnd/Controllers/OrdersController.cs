using Microsoft.AspNetCore.Mvc;
using ShopWebsite.Areas.BackEnd.Interface;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.Repository;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;
using ShopWebsite.Areas.Controllers;

namespace ShopWebsite.Areas.BackEnd.Controllers
{
    /// <summary>
    /// 訂單控制器，用於處理訂單相關的操作。
    /// </summary>
    [Area("BackEnd")]
    public class OrdersController : GenericController
    {
        IOrderRepository _orderRepository;


        /// <summary>
        /// 建構函式，初始化一個新的 OrdersController 實例。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public OrdersController(ShopWebsiteContext context) : base(context)
        {
            _orderRepository = new OrderRepository(context);
        }


        /// <summary>
        /// 顯示訂單列表的動作方法（GET）。
        /// </summary>
        /// <returns>包含訂單列表的視圖。</returns>
        public async Task<IActionResult> Index()
        {
            GetMenu();

            // 取得訂單列表的 ViewModel
            List<OrderIndexViewModel> orderViewModel = _orderRepository.GetList();

            return View(orderViewModel);
        }


        /// <summary>
        /// 顯示編輯訂單的表單的動作方法（GET）。
        /// </summary>
        /// <param name="id">要編輯的訂單的編號。</param>
        /// <returns>包含編輯訂單表單的視圖，如果找不到訂單則返回 NotFound。</returns>
        public async Task<IActionResult> Edit(int id)
        {
            GetMenu();

            // 取得編輯的訂單 ViewModel
            OrderEditViewModel orderViewModel = _orderRepository.Edit(id);

            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }


        /// <summary>
        /// 編輯訂單的動作方法（POST）。
        /// </summary>
        /// <param name="orderViewModel">包含要編輯的訂單資訊的 ViewModel。</param>
        /// <returns>編輯成功後重定向到訂單列表，否則顯示編輯表單。</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderEditViewModel orderViewModel)
        {
            GetMenu();

            if (ModelState.IsValid)
            {
                // 編輯訂單並轉向訂單列表
                _orderRepository.Edit(orderViewModel, Convert.ToInt64(HttpContext.Session.GetString("AdminNum")));

                return RedirectToAction(nameof(Index));
            }

            return View(orderViewModel);
        }


        /// <summary>
        /// 顯示詢問刪除訂單的視窗的動作方法（GET）。
        /// </summary>
        /// <param name="id">要刪除的訂單的編號。</param>
        /// <returns>包含詢問刪除操作結果的 JSON 響應。</returns>
        public async Task<IActionResult> Delete(int id)
        {
            // 刪除指定 id 的訂單
            string res = _orderRepository.Delete(id);

            return Json(res);
        }


        /// <summary>
        /// 確定刪除訂單的動作方法（POST）。
        /// </summary>
        /// <param name="id">要確認刪除的訂單的編號。</param>
        /// <returns>包含刪除成功提示的 JSON 響應。</returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // 確認刪除指定 id 的訂單
            _orderRepository.DeleteConfirmed(id);

            return Json("刪除成功");
        }


        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }

}
