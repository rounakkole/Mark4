using Microsoft.AspNetCore.Components.Authorization;
//using static Microsoft.AspNetCore.Http.IHttpContextAccessor;

namespace Mark4.Services
{
    public class LoginUserService : ILoginUserService
    {
        //youtu.be/w8imy7LT9zY
        public String? userName;
        public String? userId;
        private IHttpContextAccessor _httpContextAccessor;
        public string GetLoginUserNameAsync(AuthenticationState _authstate)
        {
            AuthenticationState authstate = _authstate; 
            userName = authstate.User.Identity.Name;
            return userName;
        }
        public string GetLoginUserIdAsync(IHttpContextAccessor httpContextAccessor)
        {
            userId = string.Empty;
            //var User = httpContextAccessor.HttpContext?.User;
            //userId = authstate.User.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userId;
            //throw new NotImplementedException();
        }
    }
}
