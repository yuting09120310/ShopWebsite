using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作管理員資料的存取介面。
    /// </summary>
    public interface IAdminRepository
    {
        /// <summary>
        /// 取得管理員清單的檢視模型。
        /// </summary>
        /// <returns>管理員清單的檢視模型集合。</returns>
        List<AdminIndexViewModel> GetList();


        /// <summary>
        /// 取得管理員群組的下拉選單項目。
        /// </summary>
        /// <returns>管理員群組的下拉選單項目集合。</returns>
        List<SelectListItem> GetAdminGroups();


        /// <summary>
        /// 建立新的管理員的檢視模型。
        /// </summary>
        /// <returns>新的管理員的檢視模型。</returns>
        AdminCreateViewModel Create();


        /// <summary>
        /// 建立新的管理員。
        /// </summary>
        /// <param name="adminViewModel">管理員的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(AdminCreateViewModel adminViewModel, long AdminNum);


        /// <summary>
        /// 編輯現有管理員的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的管理員編號。</param>
        /// <returns>編輯管理員的檢視模型。</returns>
        AdminEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯現有管理員。
        /// </summary>
        /// <param name="adminViewModel">管理員的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(AdminEditViewModel adminViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定管理員的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的管理員編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定管理員。
        /// </summary>
        /// <param name="id">要刪除的管理員編號。</param>
        void DeleteConfirmed(long? id);
    }

}
