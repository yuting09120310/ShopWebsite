using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作產品資料的存取介面。
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 取得產品清單的檢視模型。
        /// </summary>
        /// <returns>產品清單的檢視模型集合。</returns>
        List<ProductIndexViewModel> GetList();


        /// <summary>
        /// 建立新的產品。
        /// </summary>
        /// <param name="ProductViewModel">產品的建立檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(ProductCreateViewModel ProductViewModel, long AdminNum);


        /// <summary>
        /// 編輯指定產品的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的產品編號。</param>
        /// <returns>編輯產品的檢視模型。</returns>
        ProductEditViewModel Edit(long? id);

        /// <summary>
        /// 編輯指定產品。
        /// </summary>
        /// <param name="ProductViewModel">產品的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(ProductEditViewModel ProductViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定產品的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的產品編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定產品。
        /// </summary>
        /// <param name="id">要刪除的產品編號。</param>
        /// <param name="path">檔案路徑。</param>
        void DeleteConfirmed(long? id, string path);


        /// <summary>
        /// 儲存檔案至指定路徑。
        /// </summary>
        /// <param name="file">要儲存的檔案。</param>
        /// <param name="path">儲存路徑。</param>
        void SaveFile(IFormFile file, string path);


        /// <summary>
        /// 取得產品分類選單的檢視模型。
        /// </summary>
        /// <returns>產品分類選單的檢視模型集合。</returns>
        List<SelectListItem> GetProductClasseList();
    }

}
