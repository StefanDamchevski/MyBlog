using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class AuthService : IAuthService
    {
        private IUserRepository UserRepository { get; set; }
        public AuthService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public async Task<bool> SignIn(string username, string password, HttpContext httpContext)
        {
            var user = UserRepository.GetByUsername(username);
            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}