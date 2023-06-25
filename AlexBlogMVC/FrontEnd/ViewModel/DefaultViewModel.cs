using ShopWebsite.Areas.BackEnd.Models;

namespace ShopWebsite.FrontEnd.ViewModel
{
    public class DefaultViewModel
    {
        public List<Banner> lstBanner { get; set; }

        public List<NewsPageViewModel> lstNewsPageViewModel { get; set; }


        public List<SingleProductViewModel> lstShopPageViewModel { get; set; }
    }
}
