using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            // 未登入，導向登入頁面
            context.Response.Redirect("/Admin/Login/Index");
        }
        else
        {
            // 已登入，繼續執行下一個 Middleware 或 Action
            await _next(context);
        }
    }
}
