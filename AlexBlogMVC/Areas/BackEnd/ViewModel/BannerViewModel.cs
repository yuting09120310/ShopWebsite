using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class BannerViewModel
    {
        [Display(Name = "編號")]
        public long BannerNum { get; set; }

        public string? Lang { get; set; }

        [Display(Name = "類別")]
        public long? ProductClass { get; set; }

        [Display(Name = "排序")]
        public long? BannerSort { get; set; }

        [Display(Name = "標題")]
        public string? BannerTitle { get; set; }

        [Display(Name = "說明")]
        public string? BannerDescription { get; set; }

        [Display(Name = "內容")]
        public string? BannerContxt { get; set; }

        [Display(Name = "圖片")]
        public string? BannerImg1 { get; set; }

        public string? BannerImgUrl { get; set; }

        [Display(Name = "alt")]
        public string? BannerImgAlt { get; set; }

        [Display(Name = "狀態")]
        public bool? BannerPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? BannerPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編輯人ID")]
        public long? Editor { get; set; }

        public string? Ip { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? BannerOffTime { get; set; }

        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "最後編輯人")]
        public string? EditorName { get; set; }

        public IFormFile? FileData { get; set; }
    }
}
