using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel
{
    public class ProductClassIndexViewModel
    {
        [Display(Name = "編號")]
        public long ProductClassNum { get; set; }

        [Display(Name = "標題")]
        public string? ProductClassName { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductClassPublish { get; set; }

    }
}
