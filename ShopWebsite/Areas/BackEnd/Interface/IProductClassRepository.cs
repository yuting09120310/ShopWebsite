using ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作產品分類資料的存取介面。
    /// </summary>
    public interface IProductClassRepository
    {
        /// <summary>
        /// 取得產品分類清單的檢視模型。
        /// </summary>
        /// <returns>產品分類清單的檢視模型集合。</returns>
        List<ProductClassIndexViewModel> GetList();


        ProductClassCreateViewModel Create();


        /// <summary>
        /// 建立新的產品分類。
        /// </summary>
        /// <param name="productClassViewModel">產品分類的建立檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(ProductClassCreateViewModel productClassViewModel, long AdminNum);


        /// <summary>
        /// 編輯指定產品分類的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的產品分類編號。</param>
        /// <returns>編輯產品分類的檢視模型。</returns>
        ProductClassEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯指定產品分類。
        /// </summary>
        /// <param name="productClassViewModel">產品分類的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(ProductClassEditViewModel productClassViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定產品分類的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的產品分類編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定產品分類。
        /// </summary>
        /// <param name="id">要刪除的產品分類編號。</param>
        void DeleteConfirmed(long? id);
    }

}
