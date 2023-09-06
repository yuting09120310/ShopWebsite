using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel
{
    public class AdminGroupIndexViewModel
    {
        [Display(Name = "群組編號")]
        public long GroupNum { get; set; }

        [Display(Name = "群組名稱")]
        public string? GroupName { get; set; }

        [Display(Name = "狀態")]
        public bool? GroupPublish { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
    }
}
