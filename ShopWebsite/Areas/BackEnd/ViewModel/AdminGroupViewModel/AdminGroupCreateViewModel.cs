using ShopWebsite.Areas.BackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.AdminGroupViewModel
{
    public class AdminGroupCreateViewModel
    {
        [Display(Name = "群組名稱")]
        public string? GroupName { get; set; }

        [Display(Name = "說明")]
        public string? GroupInfo { get; set; }

        [Display(Name = "狀態")]
        public bool? GroupPublish { get; set; }

        public List<AdminRole> AdminRoleModels { get; set; }

        public List<MenuGroup> MenuGroupModels { get; set; }

        public List<MenuSub> MenuSubModels { get; set; }
    }
}
