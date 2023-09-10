﻿using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.OrderViewModel
{
    public class NewsEditViewModel
    {
        [Display(Name = "編號")]
        public long NewsNum { get; set; }

        [Display(Name = "標題")]
        public string? NewsTitle { get; set; }

        [Display(Name = "分類")]
        public long NewsClass { get; set; }

        [Display(Name = "說明")]
        public string? NewsDescription { get; set; }

        [Display(Name = "內容")]
        public string? NewsContxt { get; set; }

        [Display(Name = "圖片")]
        public IFormFile? NewsImg1 { get; set; }

        [Display(Name = "狀態")]
        public bool? NewsPublish { get; set; }

        [Display(Name = "上架時間")]
        public DateTime? NewsPutTime { get; set; }

        [Display(Name = "下架時間")]
        public DateTime? NewsOffTime { get; set; }

        [Display(Name = "標籤")]
        public string? Tag { get; set; }
    }
}