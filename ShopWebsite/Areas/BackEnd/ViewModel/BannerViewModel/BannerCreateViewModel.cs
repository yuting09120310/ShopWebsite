using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.BannerViewModel
{
    public class BannerCreateViewModel
    {
        [Display(Name = "標題")]
        public string? BannerTitle { get; set; }

        [Display(Name = "說明")]
        public string? BannerDescription { get; set; }

        [Display(Name = "內容")]
        public string? BannerContxt { get; set; }

        [Display(Name = "圖片")]
        public IFormFile? BannerImg1 { get; set; }

        [Display(Name = "狀態")]
        public bool? BannerPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? BannerPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? BannerOffTime { get; set; }
    }
}
