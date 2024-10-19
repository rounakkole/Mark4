using Microsoft.AspNetCore.Components.Authorization;
//using static Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider;
namespace Mark4.Services
{
    public class LoginUserService : ILoginUserService
    {
        //youtu.be/w8imy7LT9zY
        public String? userName;
        public string GetLoginUserAsync(AuthenticationState _authstate)
        {
            AuthenticationState authstate = _authstate; 
            userName = authstate.User.Identity.Name;
            
            return userName;
            //throw new NotImplementedException();
        }
    }
}
