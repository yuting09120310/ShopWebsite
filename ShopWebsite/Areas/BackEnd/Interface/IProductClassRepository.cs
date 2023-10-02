using ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel;

namespace ShopWebsite.Areas.BackEnd.Interface
{
    public interface IProductClassRepository
    {
        public List<ProductClassIndexViewModel> GetList();


        public ProductClassCreateViewModel Create();
        public void Create(ProductClassCreateViewModel newsClassViewModel, long AdminNum);


        public ProductClassEditViewModel Edit(long? id);
        public void Edit(ProductClassEditViewModel newsViewModel, long AdminNum);


        public string Delete(long? id);
        public void DeleteConfirmed(long? id);
    }
}
