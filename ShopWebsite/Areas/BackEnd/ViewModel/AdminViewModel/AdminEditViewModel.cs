using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.AdminViewModel
{
    public class AdminEditViewModel
    {
        [Display(Name = "群組")]
        // 新增一個屬性來表示對應的AdminGroup的GroupNum
        public long? GroupNum { get; set; }

        [Display(Name = "使用者")]
        public long? AdminNum { get; set; }

        [Display(Name = "帳號")]
        public string? AdminAcc { get; set; }

        [Display(Name = "密碼")]
        public string? AdminPwd { get; set; }

        [Display(Name = "姓名")]
        public string? AdminName { get; set; }

        [Display(Name = "狀態")]

        public bool? AdminPublish { get; set; }
    }
}
