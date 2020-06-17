using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Dto;
using MyBlog.Service.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class AuthService : IAuthService
    {
        private IUserRepository UserRepository { get; set; }
        public IUserService UserService { get; set; }

        public AuthService(IUserRepository userRepository, IUserService userService)
        {
            UserRepository = userRepository;
            UserService = userService;
        }
        public async Task<Response> SignIn(string username, string password, HttpContext httpContext)
        {
            User user = UserRepository.GetByUsername(username);
            Response response = new Response();

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString()),
                    new Claim("Id", user.Id.ToString()),
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Username or password is incorrect";
                return response;
            }
        }

        public async Task SignOut(HttpContext httpContext)
        {
             await httpContext.SignOutAsync();
        }

        public Response Add(string username, string password)
        {
            Response response = UserService.Create(username, password);
            return response;
        }
    }
}