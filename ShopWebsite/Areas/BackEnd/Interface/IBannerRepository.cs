using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    /// <summary>
    /// 用於操作橫幅廣告資料的存取介面。
    /// </summary>
    public interface IBannerRepository
    {
        /// <summary>
        /// 取得橫幅廣告清單的檢視模型。
        /// </summary>
        /// <returns>橫幅廣告清單的檢視模型集合。</returns>
        List<BannerIndexViewModel> GetList();


        /// <summary>
        /// 建立新的橫幅廣告的檢視模型。
        /// </summary>
        /// <returns>新的橫幅廣告的檢視模型。</returns>
        BannerCreateViewModel Create();


        /// <summary>
        /// 建立新的橫幅廣告。
        /// </summary>
        /// <param name="bannerViewModel">橫幅廣告的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Create(BannerCreateViewModel bannerViewModel, long AdminNum);


        /// <summary>
        /// 編輯現有橫幅廣告的檢視模型。
        /// </summary>
        /// <param name="id">要編輯的橫幅廣告編號。</param>
        /// <returns>編輯橫幅廣告的檢視模型。</returns>
        BannerEditViewModel Edit(long? id);


        /// <summary>
        /// 編輯現有橫幅廣告。
        /// </summary>
        /// <param name="bannerViewModel">橫幅廣告的檢視模型。</param>
        /// <param name="AdminNum">執行操作的管理員編號。</param>
        void Edit(BannerEditViewModel bannerViewModel, long AdminNum);


        /// <summary>
        /// 刪除指定橫幅廣告的檢視模型。
        /// </summary>
        /// <param name="id">要刪除的橫幅廣告編號。</param>
        /// <returns>刪除結果的訊息。</returns>
        string Delete(long? id);


        /// <summary>
        /// 確認刪除指定橫幅廣告。
        /// </summary>
        /// <param name="id">要刪除的橫幅廣告編號。</param>
        /// <param name="path">檔案路徑。</param>
        void DeleteConfirmed(long? id, string path);


        /// <summary>
        /// 儲存檔案到指定路徑。
        /// </summary>
        /// <param name="file">要儲存的檔案。</param>
        /// <param name="path">儲存路徑。</param>
        void SaveFile(IFormFile file, string path);
    }

}
