using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class NewsViewModel
    {
        [Display(Name = "編號")]
        public long NewsNum { get; set; }

        [Display(Name = "語言")]
        public string? Lang { get; set; }

        [Display(Name = "類別")]
        public long NewsClass { get; set; }

        [Display(Name = "排序")]
        public long? NewsSort { get; set; }

        [Display(Name = "標題")]
        public string? NewsTitle { get; set; }

        [Display(Name = "描述")]
        public string? NewsDescription { get; set; }

        [Display(Name = "內容")]
        public string? NewsContxt { get; set; }

        [Display(Name = "圖片")]
        public string? NewsImg1 { get; set; }

        [Display(Name = "連結")]
        public string? NewsImgUrl { get; set; }

        public string? NewsImgAlt { get; set; }

        [Display(Name = "啟用")]
        public bool? NewsPublish { get; set; }

        public long? NewsViews { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? NewsPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "最後編輯者")]
        public string? EditorName { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編號ID")]
        public long? Editor { get; set; }

        public string? Ip { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? NewsOffTime { get; set; }


        public IFormFile? FileData { get; set; }





        [Display(Name = "編號ID")]
        public long NewsClassNum { get; set; }
        [Display(Name = "排序")]
        public long? NewsClassSort { get; set; }
        [Display(Name = "類別")]
        public string? NewsClassId { get; set; }
        [Display(Name = "類別名稱")]
        public string? NewsClassName { get; set; }

        public long? NewsClassLevel { get; set; }

        public long? NewsClassPre { get; set; }

        [Display(Name = "狀態")]
        public bool? NewsClassPublish { get; set; }
    }
}
