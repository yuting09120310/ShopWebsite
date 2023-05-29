using AlexBlogMVC.Areas.BackEnd.Models;

namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class DefaultViewModel
    {
        public List<Banner> lstBanner { get; set; }

        public List<NewsPageViewModel> lstNewsPageViewModel { get; set; }


        public List<SingleProductViewModel> lstShopPageViewModel { get; set; }
    }
}
