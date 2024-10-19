using Mark3.Data.Tables;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mark4.Services
{
    public interface ILoginUserService
    {
        public string GetLoginUserAsync(AuthenticationState _authstate);
    }
}
