using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.BackEnd.ViewModel
{
    public class AdminGroupViewModel
    {
        [Display(Name = "群組編號")]
        public long GroupNum { get; set; }
        [Display(Name = "群組名稱")]
        public string? GroupName { get; set; }
        [Display(Name = "說明")]
        public string? GroupInfo { get; set; }
        [Display(Name = "狀態")]
        public bool? GroupPublish { get; set; }
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "建立人ID")]
        public long? Creator { get; set; }
        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }
        [Display(Name = "編輯人ID")]
        public long? Editor { get; set; }
        [Display(Name = "IP")]
        public string? Ip { get; set; }
        [Display(Name = "建立人")]
        public string? CreatorName { get; set; }
        [Display(Name = "編輯人")]
        public string? EditorName { get; set; }

    }
}
