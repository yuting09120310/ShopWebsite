using Microsoft.AspNetCore.Mvc.Rendering;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;
using ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IProductRepository
    {
        public List<ProductIndexViewModel> GetList();


        public ProductCreateViewModel Create();
        public void Create(ProductCreateViewModel ProductViewModel, long AdminNum);


        public ProductEditViewModel Edit(long? id);
        public void Edit(ProductEditViewModel ProductViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id, string path);


        public void SaveFile(IFormFile file, string path);


        /// <summary>
        /// 取得分類選單
        /// </summary>
        /// <returns>List<SelectListItem></returns>
        public List<SelectListItem> GetProductClasseList();
    }
}
