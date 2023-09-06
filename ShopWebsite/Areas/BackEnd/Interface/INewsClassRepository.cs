using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.NewsViewModel;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface INewsClassRepository
    {
        public List<NewsClassIndexViewModel> GetList();


        public NewsClassCreateViewModel Create();
        public void Create(NewsClassCreateViewModel newsClassViewModel, long AdminNum);


        public NewsClassEditViewModel Edit(long? id);
        public void Edit(NewsClassEditViewModel newsViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
