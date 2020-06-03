using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        public IAuthService AuthService { get; set; }
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        public IActionResult SignIn()
        {
            var model = new SignInModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                bool isSignedIn = await AuthService.SignIn(signInModel.Username, signInModel.Password, HttpContext);
                if (isSignedIn)
                {
                    return RedirectToAction("Overview", "Blog");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(signInModel);
                }
            }
            else
            {
                return View(signInModel);
            }
        }
    }
}