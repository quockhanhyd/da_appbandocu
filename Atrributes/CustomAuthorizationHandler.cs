//using Microsoft.AspNetCore.Authorization;

//namespace DA_AppBanDoCu.Atrributes
//{
//    public class CustomAuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement>
//    {
//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
//        {
//            context.
//            if (!context.User.Identity.IsAuthenticated)
//            {
//                context.Fail();
//                return Task.CompletedTask;
//            }

//            // Tùy chỉnh logic ủy quyền của bạn ở đây

//            context.Succeed(requirement);
//            return Task.CompletedTask;
//        }
//    }
//}
