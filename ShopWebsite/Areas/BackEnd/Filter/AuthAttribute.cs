using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Areas.BackEnd.Filter
{
    /// <summary>
    /// 自訂身份驗證特性，用於標記控制器或動作方法，以執行身份驗證。
    /// </summary>
    public class AuthAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// 初始化 AuthAttribute 類別的新執行個體。
        /// </summary>
        public AuthAttribute() : base(typeof(AuthFilter))
        {

        }
    }

}
