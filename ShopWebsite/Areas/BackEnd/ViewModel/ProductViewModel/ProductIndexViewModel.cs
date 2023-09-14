using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel
{
    public class ProductIndexViewModel
    {
        [Display(Name = "編號")]
        public long ProductNum { get; set; }

        [Display(Name = "標題")]
        public string? ProductTitle { get; set; }

        [Display(Name = "說明")]
        public string? ProductDescription { get; set; }

        [Display(Name = "圖片")]
        public string? ProductImg1 { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? ProductPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "編輯時間")]
        public DateTime? EditTime { get; set; }

        public string? Ip { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? ProductOffTime { get; set; }
    }
}
