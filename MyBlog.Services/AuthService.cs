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
        public AuthService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public async Task<SignUpInResponse> SignIn(string username, string password, HttpContext httpContext)
        {
            var user = UserRepository.GetByUsername(username);
            var response = new SignUpInResponse();

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

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

        public SignUpInResponse Add(string username, string password)
        {
            var user = UserRepository.GetByUsername(username);
            var response = new SignUpInResponse();

            if(user == null)
            {
                var newUser = new User()
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                };

                UserRepository.Add(newUser);
                response.IsSuccessful = true;
                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"Username {username} already exists";
                return response;
            }
        }
    }
}