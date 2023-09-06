using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.NewsClassViewModel
{
    public class NewsClassIndexViewModel
    {
        [Display(Name = "編號")]
        public long NewsClassNum { get; set; }

        [Display(Name = "標題")]
        public string? NewsClassName { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "狀態")]
        public bool? NewsClassPublish { get; set; }

    }
}
