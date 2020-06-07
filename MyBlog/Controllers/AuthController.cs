using Microsoft.AspNetCore.Mvc;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System;
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
        public async Task<IActionResult> SignIn(SignInModel signInModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var response = await AuthService.SignIn(signInModel.Username, signInModel.Password, HttpContext);
                if (response.IsSuccessful)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Overview", "Blog");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View(signInModel);
                }
            }
            else
            {
                return View(signInModel);
            }
        }
        public async Task<IActionResult> SignOut()
        {
            await AuthService.SignOut(HttpContext);
            return RedirectToAction("Overview", "Blog");
        }
        public IActionResult SignUp()
        {
            var model = new SignUpModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var response = AuthService.Add(signUpModel.Username, signUpModel.Password);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View(signUpModel);
                }
            }
            else
            {
                return View(signUpModel);
            }
        }
    }
}