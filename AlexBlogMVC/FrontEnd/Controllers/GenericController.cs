﻿using AlexBlogMVC.BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AlexBlogMVC.FrontEnd.Controllers
{
    public class GenericController : Controller
    {
        public readonly BlogMvcContext _context;

        public GenericController(BlogMvcContext context)
        {
            _context = context;
        }

        // 呼叫每一個action都會執行
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.AdminName = "" + HttpContext.Session.GetString("AdminName");
        }


        //取得選單
        public void getMenu()
        {
            int GroupNum = Convert.ToInt16(HttpContext.Session.GetString("GroupNum"));

            var module = from c in _context.MenuGroups
                         where c.MenuGroupPublish == true
                         orderby c.MenuGroupNum ascending
                         select c;
            ViewBag.module = module.ToList();


            var moduleFun = from c in _context.MenuSubs
            join
                                            s in _context.AdminRoles on c.MenuSubNum equals s.MenuSubNum
                            where c.MenuSubPublish == true && s.GroupNum == GroupNum
                            select c;

            ViewBag.moduleFun = moduleFun.ToList();
        }

        
        // 登入判斷
        public bool LoginState()
        {
            string AdminNum = "" + HttpContext.Session.GetString("AdminNum");
            if (AdminNum.Length == 0)
            {
                return false;
            }
            return true;
        }


        //權限判斷
        public bool CheckRole(int menuSubNum, string action)
        {
            string GroupNum = HttpContext.Session.GetString("GroupNum");
            if(GroupNum == null)
            {
                return false;
            }

            var role = _context.AdminRoles.Where(x => x.GroupNum == Convert.ToInt16(GroupNum) && x.MenuSubNum == menuSubNum && x.Role.Contains(action));
            if (!role.Any())
            {
                return false;
            }

            return true;
        }



        
    }
}