using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class AdminViewModel
    {
        [Display(Name = "帳號編號")]
        public long AdminNum { get; set; }

        [Display(Name = "群組")]
        public string? GroupName { get; set; }

        [Display(Name = "帳號")]
        public string? AdminAcc { get; set; }

        [Display(Name = "密碼")]
        public string? AdminPwd { get; set; }

        [Display(Name = "姓名")]
        public string? AdminName { get; set; }

        [Display(Name = "狀態")]

        public bool? AdminPublish { get; set; }

        [Display(Name = "最後登入")]
        public DateTime? LastLogin { get; set; }

        [Display(Name = "建立日期")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編輯人ID")]
        public long? Editor { get; set; }

        [Display(Name = "最後編輯者")]
        public string? EditorName { get; set; }

        [Display(Name = "建立IP")]
        public string? Ip { get; set; }

        [Display(Name = "群組")]
        // 新增一個屬性來表示對應的AdminGroup的GroupNum
        public long? GroupNum { get; set; }
    }
}
