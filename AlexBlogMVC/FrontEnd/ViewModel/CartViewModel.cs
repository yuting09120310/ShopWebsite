using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.FrontEnd.ViewModel
{
    public class CartViewModel
    {
        public  List<SingleProductViewModel> singleProductViewModels { get; set; }

        public int Total { get; set; }

        [RegularExpression(@"^[\u4e00-\u9fa5]+$", ErrorMessage = "名字應為中文")]
        public string Name { get; set; }

        [RegularExpression(@"^09\d+$", ErrorMessage = "電話號碼應為09開頭")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "電話格式錯誤 應為10碼")]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
