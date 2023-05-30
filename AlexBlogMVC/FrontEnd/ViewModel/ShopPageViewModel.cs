using AlexBlogMVC.Areas.BackEnd.Models;

namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class ShopPageViewModel
    {
        public List<SingleProductViewModel> ListProductViewModels { get; set; }
        public List<ProductClass> ListproductClass { get; set; }
    }


    /// <summary>
    /// 單一品項
    /// </summary>
    public class SingleProductViewModel
    {
        public long ProductId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long ClassId { get; set; }

        public string ProductTypeName { get; set; }

        public DateTime CreateTime { get; set; }

        public string ProductImg1 { get; set; }

        public string contxt { get; set; }

        public int Price { get; set; }
    }
    
}
