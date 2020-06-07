using Microsoft.AspNetCore.Http;
using MyBlog.Service.Dto;
using System.Threading.Tasks;

namespace MyBlog.Service.Interfaces
{
    public interface IAuthService
    {
        Task<SignUpInResponse> SignIn(string username, string password, HttpContext httpContext);
        Task SignOut(HttpContext httpContext);
        SignUpInResponse Add(string username, string password);
    }
}
