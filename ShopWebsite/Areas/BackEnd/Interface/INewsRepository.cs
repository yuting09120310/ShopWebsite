using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作新聞資料的存取介面。
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// 取得新聞清單的檢視模型。
        /// </summary>
        /// <returns>新聞清單的檢視模型集合。</returns>
        List<NewsIndexViewModel> GetList();


        /// <summary>
        /// 建立新的新聞的檢視模型。
        /// </summary>
        /// <returns>新的新聞的檢視模型。</returns>
        NewsCreateViewModel Create();

        /// <summary>
        /// 建立新的新聞。
        /// </summary>
        /// <param name="newsViewModel">新聞的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(NewsCreateViewModel newsViewModel, long AdminNum);


        /// <summary>
        /// 編輯現有新聞的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的新聞編號。</param>
        /// <returns>編輯新聞的檢視模型。</returns>
        NewsEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯現有新聞。
        /// </summary>
        /// <param name="newsViewModel">新聞的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(NewsEditViewModel newsViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定新聞的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的新聞編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定新聞。
        /// </summary>
        /// <param name="id">要刪除的新聞編號。</param>
        /// <param name="path">新聞圖片的路徑。</param>
        void DeleteConfirmed(long? id, string path);


        /// <summary>
        /// 儲存檔案至指定路徑。
        /// </summary>
        /// <param name="file">要儲存的檔案。</param>
        /// <param name="path">儲存的目標路徑。</param>
        void SaveFile(IFormFile file, string path);


        /// <summary>
        /// 取得新聞分類的選單清單。
        /// </summary>
        /// <returns>新聞分類的選單清單。</returns>
        List<SelectListItem> GetNewsClasseList();
    }

}
