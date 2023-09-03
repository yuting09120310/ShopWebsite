using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.Models;
using ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel;
using ShopWebsite.Areas.ViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IBannerRepository
    {
        public List<BannerIndexViewModel> GetList();


        public BannerCreateViewModel Create();
        public void Create(BannerCreateViewModel bannerViewModel, long AdminNum);


        public BannerEditViewModel Edit(long? id);
        public void Edit(BannerEditViewModel bannerViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id, string path);


        public void SaveFile(IFormFile file, string path);
    }
}
