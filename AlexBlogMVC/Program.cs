using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc.Razor;

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
    pattern: "{area:exists}/{controller}/{action=Index}/{id?}/");


app.MapControllerRoute(
    name: "front",
    pattern: "/{controller=Default}/{action=Index}/{id?}/");


app.Run();
