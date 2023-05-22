using AlexBlogMVC.Areas.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    // 設定 Session 有效時間為 30 分鐘
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Clear();
    options.ViewLocationFormats.Add("/Areas/BackEnd/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/Areas/BackEnd/Views/Shared/{0}" + RazorViewEngine.ViewExtension);

    options.ViewLocationFormats.Add("/FrontEnd/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
    options.ViewLocationFormats.Add("/FrontEnd/Views/Shared/{0}" + RazorViewEngine.ViewExtension);

});

builder.Services.AddDbContext<BlogMvcContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


// Areas區域Route配置 （Controller需增加屬性 EX：[Area("Admin")]）
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "admin",
    pattern: "/BackEnd/{controller=Login}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "front",
    pattern: "/{controller=NewsPage}/{action=Index}/{id?}");

app.Run();
