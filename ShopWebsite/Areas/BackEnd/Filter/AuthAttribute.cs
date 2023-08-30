using Microsoft.AspNetCore.Mvc;

namespace ShopWebsite.Areas.BackEnd.Filter
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute() : base(typeof(AuthFilter))
        {

        }
    }
}
