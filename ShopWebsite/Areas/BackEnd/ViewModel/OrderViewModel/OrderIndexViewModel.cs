using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel
{
    public class NewsIndexViewModel
    {
        [Display(Name = "編號")]
        public long NewsNum { get; set; }

        [Display(Name = "標題")]
        public string? NewsTitle { get; set; }

        [Display(Name = "說明")]
        public string? NewsDescription { get; set; }

        [Display(Name = "圖片")]
        public string? NewsImg1 { get; set; }

        [Display(Name = "狀態")]
        public bool? NewsPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? NewsPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        public string? Ip { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? NewsOffTime { get; set; }
    }
}
