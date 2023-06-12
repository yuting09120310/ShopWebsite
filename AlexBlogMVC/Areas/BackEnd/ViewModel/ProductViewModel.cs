using System.ComponentModel.DataAnnotations;

namespace AlexBlogMVC.Areas.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "編號")]
        public long ProductNum { get; set; }

        [Display(Name = "語言")]
        public string? Lang { get; set; }

        [Display(Name = "類別")]
        public long ProductClass { get; set; }

        [Display(Name = "排序")]
        public long? ProductSort { get; set; }

        public string? ProductDepartment { get; set; }

        public string? ProductId { get; set; }

        [Display(Name = "標題")]
        public string? ProductTitle { get; set; }

        [Display(Name = "簡述")]
        public string? ProductDescription { get; set; }

        [Display(Name = "內文")]
        public string? ProductContxt { get; set; }

        [Display(Name = "圖片")]
        public string? ProductImg1 { get; set; }

        [Display(Name = "連結")]
        public string? ProductImgUrl { get; set; }

        [Display(Name = "alt")]
        public string? ProductImgAlt { get; set; }

        [Display(Name = "圖片List")]
        public string? ProductImgList { get; set; }


        public string? ProductImgListAlt { get; set; }


        [Display(Name = "價格")]
        public int ProductPrice { get; set; }


        public string? ProductVideo1 { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductPublish { get; set; }

        [Display(Name = "上架時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProductPutTime { get; set; }

        [Display(Name = "建立時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        [Display(Name = "新增者ID")]
        public long? Creator { get; set; }

        [Display(Name = "編輯時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EditTime { get; set; }

        [Display(Name = "編號ID")]
        public long? Editor { get; set; }

        public string? Ip { get; set; }

        [Display(Name = "下架時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ProductOffTime { get; set; }


        [Display(Name = "新增者")]
        public string? CreatorName { get; set; }

        [Display(Name = "最後編輯者")]
        public string? EditorName { get; set; }

        public IFormFile? FileData { get; set; }

        public string Tag { get; set; }


        public List<IFormFile>? FileDatas { get; set; }
    }
}
