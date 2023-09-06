using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel
{
    public class NewsClassCreateViewModel
    {
        [Display(Name = "標題")]
        public string NewsClassName { get; set; }

        [Display(Name = "排序")]
        public long? NewsClassSort { get; set; }

        [Display(Name = "狀態")]
        public bool NewsClassPublish { get; set; }
    }
}
