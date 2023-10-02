using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作訂單資料的存取介面。
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// 取得訂單清單的檢視模型。
        /// </summary>
        /// <returns>訂單清單的檢視模型集合。</returns>
        List<OrderIndexViewModel> GetList();


        /// <summary>
        /// 編輯指定訂單的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的訂單編號。</param>
        /// <returns>編輯訂單的檢視模型。</returns>
        OrderEditViewModel Edit(long id);


        /// <summary>
        /// 編輯指定訂單。
        /// </summary>
        /// <param name="orderViewModel">訂單的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(OrderEditViewModel orderViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定訂單的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的訂單編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long id);


        /// <summary>
        /// 確認刪除指定訂單。
        /// </summary>
        /// <param name="id">要刪除的訂單編號。</param>
        void DeleteConfirmed(long id);
    }

}
