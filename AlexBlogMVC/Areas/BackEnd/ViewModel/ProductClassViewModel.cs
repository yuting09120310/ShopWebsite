using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class ProductClassViewModel
    {
        [Display(Name = "編號")]
        public long ProductClassNum { get; set; }

        [Display(Name = "排序")]
        public long? ProductClassSort { get; set; }

        public string? ProductClassId { get; set; }

        [Display(Name = "標題")]
        public string? ProductClassName { get; set; }

        public long? ProductClassLevel { get; set; }

        public long? ProductClassPre { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductClassPublish { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編輯人ID")]
        public long? Editor { get; set; }

        public string? Ip { get; set; }


        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "最後編輯人")]
        public string? EditorName { get; set; }
    }
}
