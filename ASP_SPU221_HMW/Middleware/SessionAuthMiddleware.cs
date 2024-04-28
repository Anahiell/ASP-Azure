using ASP_SPU221_HMW.Data.Dal;
using System.Security.Claims;

namespace ASP_SPU221_HMW.Middleware
{
    public class SessionAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public SessionAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
       
        public async Task InvokeAsync(HttpContext context, DataAccessor dataAccessor)
        {
            var userId = context.Session.GetString("auth-user-id");
            if (userId != null) 
            {
                
                var user = dataAccessor.UserDao.GetUserById(userId);
                if (user != null)
                {
                   
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Sid,user.Id.ToString()),
                        new Claim(ClaimTypes.UserData,user.AvatarUrl ?? ""),
                        new Claim(ClaimTypes.DateOfBirth, user.Birthdate.ToString() ?? "")

                    };
                   
                    context.User = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            claims, nameof(SessionAuthMiddleware)) 
                        );
                }

            }
            
            await _next(context);
        }
    }
    public static class SessionAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseSessionAuth(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionAuthMiddleware>();
        }
    }
}

