using ShopWebsite.Areas.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace ShopWebsite.FrontEnd.Controllers
{
    public class GenericController : Controller
    {
        public readonly BlogMvcContext _context;

        public GenericController(BlogMvcContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 取得廣告
        /// </summary>
        public void GetBanner()
        {
            DateTime today = DateTime.Today;

            Banner banner = _context.Banners
                .Where(x => x.BannerPublish == true && x.BannerPutTime < today && x.BannerOffTime > today)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault()!;

            ViewBag.Banner = banner.BannerImg1;
        }


        /// <summary>
        /// 取得Navbar 最新消息類別
        /// </summary>
        public void GetNewsType()
        {
            List<NewsClass> newsClass = _context.NewsClasses.Where(x => x.NewsClassPublish == true).ToList();
            ViewBag.NewsType = newsClass;
        }


        /// <summary>
        /// 發送信件
        /// </summary>
        /// <param name="email">電子信箱</param>
        /// <param name="title">標題</param>
        /// <param name="content">內文</param>
        public void SendMail(string email, string title, string content)
        {
            // 設定寄件人和收件人的電子郵件地址
            string fromEmail = "yutingcai0912@gmail.com";
            string toEmail = email;

            // 設定SMTP伺服器的相關資訊
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "yutingcai0912@gmail.com";
            string smtpPassword = "xolhscojpeduwwai";

            // 建立MailMessage物件
            MailMessage mail = new MailMessage(fromEmail, toEmail);
            mail.Subject = title;
            mail.Body = content;

            // 建立SmtpClient物件並設定相關資訊
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // 發送郵件
                smtpClient.Send(mail);
                Console.WriteLine("郵件已成功發送！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("發送郵件時發生錯誤：" + ex.Message);
            }
        }
    }
}
