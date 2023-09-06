using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel
{
    public class AdminIndexViewModel
    {
        [Display(Name = "帳號編號")]
        public long AdminNum { get; set; }

        [Display(Name = "帳號")]
        public string? AdminAcc { get; set; }

        [Display(Name = "姓名")]
        public string? AdminName { get; set; }

        [Display(Name = "狀態")]

        public bool? AdminPublish { get; set; }

        [Display(Name = "群組")]
        public string? GroupName { get; set; }

        [Display(Name = "最後登入")]
        public DateTime? LastLogin { get; set; }
    }
}
