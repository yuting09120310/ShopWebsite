using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.FrontEnd.ViewModel
{
    public class CartViewModel
    {
        public  List<SingleProductViewModel> singleProductViewModels { get; set; }

        public int Total { get; set; }

        [RegularExpression(@"^[\u4e00-\u9fa5]+$", ErrorMessage = "名字應為中文")]
        public string Name { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "電子信箱格式不正確")]
        public string EMail { get; set; }


        public string Address { get; set; }
    }
}
