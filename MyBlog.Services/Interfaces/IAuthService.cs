using Microsoft.AspNetCore.Http;
using MyBlog.Service.Dto;
using System.Threading.Tasks;

namespace MyBlog.Service.Interfaces
{
    public interface IAuthService
    {
        Task<Response> SignIn(string username, string password, HttpContext httpContext);
        Task SignOut(HttpContext httpContext);
        Response Add(string username, string password);
    }
}
