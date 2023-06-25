namespace ShopWebsite.FrontEnd.ViewModel
{
    /// <summary>
    /// 單一品項
    /// </summary>
    public class SingleProductViewModel
    {
        public long ProductId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public long ClassId { get; set; }

        public string? ProductTypeName { get; set; }

        public DateTime CreateTime { get; set; }

        public string? ProductImg1 { get; set; }

        public string? ProductImgList { get; set; }

        public string? contxt { get; set; }

        public int Price { get; set; }

        public int amount { get; set; }

        public string tag { get; set; }
    }
}
