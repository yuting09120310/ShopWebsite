using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopWebsite.Areas.BackEnd.Models;
using System.Data;

namespace ShopWebsite.Areas.BackEnd.Filter
{
    /// <summary>
    /// 自訂身份驗證過濾器，用於確保使用者已登入並擁有訪問權限。
    /// </summary>
    public class AuthFilter : IAuthorizationFilter
    {
        private readonly ShopWebsiteContext _context;


        /// <summary>
        /// 初始化 AuthFilter 類別的新執行個體。
        /// </summary>
        /// <param name="context">應用程式的資料庫上下文。</param>
        public AuthFilter(ShopWebsiteContext context)
        {
            _context = context;
        }


        /// <summary>
        /// 在執行動作方法之前執行身份驗證和權限檢查。
        /// </summary>
        /// <param name="authorizationFilterContext">授權過濾器上下文。</param>
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            // 從 Session 中獲取使用者相關資訊
            string GroupNum = authorizationFilterContext.HttpContext.Session.GetString("GroupNum");
            string AdminName = authorizationFilterContext.HttpContext.Session.GetString("AdminName");
            string AdminNum = authorizationFilterContext.HttpContext.Session.GetString("AdminNum");

            // 判斷使用者是否登入
            if (string.IsNullOrEmpty(GroupNum) || string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminNum))
            {
                // 如果未登入，將使用者重定向到登入頁面並顯示提示訊息
                authorizationFilterContext.Result = new ContentResult()
                {
                    Content = "<script>alert('尚未登入');window.location.href='/Backend/Login/Index'</script>",
                    ContentType = "text/html;charset=utf-8",
                };

                return;
            }

            // 獲取控制器和動作名稱以進行權限檢查
            string controllerName = authorizationFilterContext.RouteData.Values["Controller"].ToString();
            string actionName = authorizationFilterContext.RouteData.Values["Action"].ToString();

            // 檢查使用者是否具有訪問該動作的權限
            if (controllerName != "Home")
            {
                // 定義動作和對應的權限
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Create", "C");
                dic.Add("Index", "R");
                dic.Add("Edit", "U");
                dic.Add("Delete", "D");
                dic.Add("DeleteConfirmed", "D");

                // 獲取與該控制器動作相關的 MenuSubNum
                List<long> menuSubNums = _context.MenuSubs
                    .Where(ms => ms.MenuSubUrl.StartsWith($"/BackEnd/{controllerName}/"))
                    .Select(ms => ms.MenuSubNum)
                    .ToList();

                string menuNum = menuSubNums[0].ToString();

                // 檢查使用者是否具有該動作的權限
                List<long?> Role = _context.AdminRoles
                    .Where(ms => ms.GroupNum == Convert.ToInt64(GroupNum) && ms.MenuSubNum == Convert.ToInt64(menuNum) && ms.Role.Contains($"{dic[actionName].ToString()}"))
                    .Select(ms => ms.MenuSubNum)
                    .ToList();

                if (Role.Count == 0)
                {
                    // 如果權限不足，將使用者重定向並顯示提示訊息
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
