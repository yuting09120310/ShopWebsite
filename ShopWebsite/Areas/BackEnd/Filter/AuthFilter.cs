using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopWebsite.Areas.BackEnd.Models;
using System.Data;

namespace ShopWebsite.Areas.BackEnd.Filter
{
    public class AuthFilter : IAuthorizationFilter
    {
        public ShopWebsiteContext _context;

        public AuthFilter(ShopWebsiteContext context)
        {
            _context = context;
        }

        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            string GroupNum = authorizationFilterContext.HttpContext.Session.GetString("GroupNum");
            string AdminName = authorizationFilterContext.HttpContext.Session.GetString("AdminName");
            string AdminNum = authorizationFilterContext.HttpContext.Session.GetString("AdminNum");

            // 判斷使用者是否登入            
            if (string.IsNullOrEmpty(GroupNum) || string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminNum))
            {
                authorizationFilterContext.Result = new ContentResult()
                {
                    Content = "<script>alert('尚未登入');window.location.href='/Backend/Login/Index'</script>",
                    ContentType = "text/html;charset=utf-8",
                };

                return;
            }

            string controllerName = authorizationFilterContext.RouteData.Values["Controller"].ToString();
            string actionName = authorizationFilterContext.RouteData.Values["Action"].ToString();

            if (controllerName != "Home")
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Create", "C");
                dic.Add("Index", "R");
                dic.Add("Edit", "U");
                dic.Add("Delete", "D");

                List<long> menuSubNums = _context.MenuSubs
                                 .Where(ms => ms.MenuSubUrl.StartsWith($"/BackEnd/{controllerName}/"))
                                 .Select(ms => ms.MenuSubNum)
                                 .ToList();

                string menuNum = menuSubNums[0].ToString();

                List<long?> Role = _context.AdminRoles
                                 .Where(ms => ms.GroupNum == Convert.ToInt64(GroupNum) && ms.MenuSubNum == Convert.ToInt64(menuNum) && ms.Role.Contains($"{dic[actionName].ToString()}"))
                                 .Select(ms => ms.MenuSubNum)
                                 .ToList();

                if (Role.Count == 0)
                {
                    authorizationFilterContext.Result = new ContentResult()
                    {
                        Content = "<script>alert('權限不足');history.back()</script>",
                        ContentType = "text/html;charset=utf-8",
                    };

                    return;
                }
            }
        }
    }
}
