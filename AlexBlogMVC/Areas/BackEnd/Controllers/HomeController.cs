﻿using ShopWebsite.Areas.Controllers;
using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Controllers
{
    public class HomeController : GenericController
    {
        public HomeController(BlogMvcContext context) : base(context) { }


        public IActionResult Index()
        {
            GetMenu();

            return View();
        }
    }
}