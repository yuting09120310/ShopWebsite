using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface INewsRepository
    {
        public List<NewsIndexViewModel> GetList();


        public NewsCreateViewModel Create();
        public void Create(NewsCreateViewModel newsViewModel, long AdminNum);


        public NewsEditViewModel Edit(long? id);
        public void Edit(NewsEditViewModel newsViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id, string path);


        public void SaveFile(IFormFile file, string path);


        /// <summary>
        /// 取得分類選單
        /// </summary>
        /// <returns>List<SelectListItem></returns>
        public List<SelectListItem> GetNewsClasseList();
    }
}
