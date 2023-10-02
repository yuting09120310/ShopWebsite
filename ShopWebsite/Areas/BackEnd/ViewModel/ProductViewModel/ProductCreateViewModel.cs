using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.ProductViewModel
{
    public class ProductCreateViewModel
    {
        [Display(Name = "分類")]
        public long ProductClass { get; set; }

        [Display(Name = "標題")]
        public string? ProductTitle { get; set; }

        [Display(Name = "說明")]
        public string? ProductDescription { get; set; }

        [Display(Name = "內容")]
        public string? ProductContxt { get; set; }

        [Display(Name = "封面圖")]
        public IFormFile? ProductImg1 { get; set; }

        [Display(Name = "產品圖")]
        public List<IFormFile>? ProductImgList { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? ProductPutTime { get; set; }

        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? ProductOffTime { get; set; }

        [Display(Name = "標籤")]
        public string? Tag { get; set; }
    }
}
