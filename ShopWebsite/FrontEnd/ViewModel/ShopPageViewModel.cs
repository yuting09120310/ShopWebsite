using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.FrontEnd.ViewModel
{
    public class ShopPageViewModel
    {
        public List<SingleProductViewModel> ListProductViewModels { get; set; }
        public List<ProductClass> ListproductClass { get; set; }

        public List<SingleProductViewModel> TopProducts { get; set; }
    }
}
