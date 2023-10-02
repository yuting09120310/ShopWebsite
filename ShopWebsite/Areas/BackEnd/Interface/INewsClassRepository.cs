using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作新聞類別資料的存取介面。
    /// </summary>
    public interface INewsClassRepository
    {
        /// <summary>
        /// 取得新聞類別清單的檢視模型。
        /// </summary>
        /// <returns>新聞類別清單的檢視模型集合。</returns>
        List<NewsClassIndexViewModel> GetList();


        /// <summary>
        /// 建立新的新聞類別的檢視模型。
        /// </summary>
        /// <returns>新的新聞類別的檢視模型。</returns>
        NewsClassCreateViewModel Create();


        /// <summary>
        /// 建立新的新聞類別。
        /// </summary>
        /// <param name="newsClassViewModel">新聞類別的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(NewsClassCreateViewModel newsClassViewModel, long AdminNum);


        /// <summary>
        /// 編輯現有新聞類別的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的新聞類別編號。</param>
        /// <returns>編輯新聞類別的檢視模型。</returns>
        NewsClassEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯現有新聞類別。
        /// </summary>
        /// <param name="newsViewModel">新聞類別的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(NewsClassEditViewModel newsViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定新聞類別的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的新聞類別編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定新聞類別。
        /// </summary>
        /// <param name="id">要刪除的新聞類別編號。</param>
        void DeleteConfirmed(long? id);
    }

}
