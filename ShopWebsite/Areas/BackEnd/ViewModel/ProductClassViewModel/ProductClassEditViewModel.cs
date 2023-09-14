﻿using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Areas.BackEnd.ViewModel.ProductClassViewModel
{
    public class ProductClassEditViewModel
    {
        [Display(Name = "編號")]
        public long ProductClassNum { get; set; }

        [Display(Name = "標題")]
        public string ProductClassName { get; set; }

        [Display(Name = "排序")]
        public long? ProductClassSort { get; set; }

        [Display(Name = "狀態")]
        public bool? ProductClassPublish { get; set; }
    }
}
