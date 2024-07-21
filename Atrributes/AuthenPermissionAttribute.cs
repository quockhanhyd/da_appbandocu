using DA_AppBanDoCu.Controllers;
using DA_AppBanDoCu.Utils;
using DA_AppBanDoCu.ViewModels.Responses.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DA_AppBanDoCu.Atrributes
{
    public class AuthenPermissionAttribute : AuthorizeAttribute, IAsyncActionFilter
    {
        public AuthenPermissionAttribute()
        {
        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Kiểm tra authen
            if (context.Controller.GetType().IsSubclassOf(typeof(Authentication)))
            {
                var result = ((Authentication)context.Controller).ResultCheckToken;
                if (!result.IsOk)
                {
                    return Task.CompletedTask;
                }

                string token = context.HttpContext.Request.Headers["Authentication"];
                if (token != null) token = token.Replace("Bearer ", "");

                JwtUtils.ValidateJwtToken(token);

                // Check quyền
                string msg = CheckPermission(context);
                if (msg.Length > 0)
                {
                    string perrmissionDenied = "Bạn không có quyền thực hiện chức năng này.";
                    context.Result = new ContentResult
                    {
                        Content = JsonConvert.SerializeObject(new Result() { IsOk = false, ErrorMessage = perrmissionDenied, Status = 403 }),
                        ContentType = "application/json",
                        StatusCode = 200
                    };
                    return Task.CompletedTask;
                }
            }
            next();
            return Task.CompletedTask;
        }
        public string GetRequestBody(HttpRequest request)
        {
            var bodyStream = new StreamReader(request.Body);
            bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
            var bodyText = bodyStream.ReadToEnd();
            return bodyText;
        }

        public string CheckPermission(ActionExecutingContext context)
        {
            // todo 
            return "";
        }

    }
}
