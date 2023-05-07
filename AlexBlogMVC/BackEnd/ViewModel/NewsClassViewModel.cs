using AlexBlogMVC.BackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.ViewModel
{
    public class NewsClassViewModel
    {
        [Display(Name = "編號ID")]
        public long NewsClassNum { get; set; }

        [Display(Name = "排序")]
        public long? NewsClassSort { get; set; }

        [Display(Name = "類別")]
        public string? NewsClassId { get; set; }

        [Display(Name = "名稱")]
        public string? NewsClassName { get; set; }

        public long? NewsClassLevel { get; set; }

        public long? NewsClassPre { get; set; }

        [Display(Name = "狀態")]
        public bool? NewsClassPublish { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編輯者ID")]
        public long? Editor { get; set; }

        [Display(Name = "最後編輯者")]
        public string? EditorName { get; set; }

        public string? Ip { get; set; }
    }
}
