using ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作管理員群組的資料存取介面。
    /// </summary>
    public interface IAdminGroupRepository
    {
        /// <summary>
        /// 取得管理員群組清單的檢視模型。
        /// </summary>
        /// <returns>管理員群組清單的檢視模型集合。</returns>
        List<AdminGroupIndexViewModel> GetList();


        /// <summary>
        /// 建立新的管理員群組的檢視模型。
        /// </summary>
        /// <returns>新的管理員群組的檢視模型。</returns>
        AdminGroupCreateViewModel Create();


        /// <summary>
        /// 建立新的管理員群組。
        /// </summary>
        /// <param name="Collection">表單資料的集合。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(IFormCollection Collection, long AdminNum);


        /// <summary>
        /// 編輯現有管理員群組的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的管理員群組編號。</param>
        /// <returns>編輯管理員群組的檢視模型。</returns>
        AdminGroupEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯現有管理員群組。
        /// </summary>
        /// <param name="Collection">表單資料的集合。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(IFormCollection Collection, long AdminNum);


        /// <summary>
        /// 刪除指定管理員群組的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的管理員群組編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定管理員群組。
        /// </summary>
        /// <param name="id">要刪除的管理員群組編號。</param>
        void DeleteConfirmed(long? id);
    }

}
