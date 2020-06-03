using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBlog.Service.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignIn(string username, string password, HttpContext httpContext);
    }
}
