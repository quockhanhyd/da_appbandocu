using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Responses.Base;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DA_AppBanDoCu.Atrributes
{
    public class CustomUnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomUnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = (context.Request.Path.Value ?? "").ToLower();

            var listApi = new[] { "api/user" };
            if (listApi.Any(a => path.Contains(a)))
            {
                string token = context.Request.Headers["Authorization"];
                if (token != null) token = token.Replace("Bearer ", "");

                string userID = JwtUtils.ValidateJwtToken(token);

                if (userID == null)
                {
                    context.Response.StatusCode = StatusCodes.Status200OK; //StatusCodes.Status401Unauthorized; -- default 200 do 401 trả trong data
                    string permissionDenied = "Bạn không có quyền truy cập tài nguyên này.";
                    context.Response.ContentType = "application/json";
                    var response = new Result() { IsOk = false, ErrorMessage = permissionDenied, Status = 401 };
                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
                    return;
                }
            }

            await _next(context);
        }
    }
}
