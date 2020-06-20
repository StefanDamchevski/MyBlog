using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Custom;
using MyBlog.Data;
using MyBlog.Helpers;
using MyBlog.Service.Dto;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult ModifyUsersOverview()
        {
            List<User> users = UserService.GetAll();
            List<ModifyUsersOverviewModel> model = users
                .Select(x => ModelConverter.ConvertToModifyUsersOverviewModel(x))
                .ToList();

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            if(!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccesssDenied", "Auth");
            }
            else
            {
                UserService.Delete(id);
            }
            if (Convert.ToInt32(User.FindFirst("Id").Value) == id)
            {
                return RedirectToAction("SignOut", "Auth");
            }
            else
            {
                return RedirectToAction("Success");
            }
        }
        public IActionResult ModifyUser(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                User user = UserService.GetById(id);
                ModifyUserModel model = ModelConverter.ConvertToModifyUserModel(user);
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult ModifyUser(ModifyUserModel model)
        {
            if (!AuthorizeService.AuthorizeUser(User, model.Id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Response response = UserService.UpdateUser(model.Id, model.Username);
                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("Success");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response.Message);
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
        }
        public IActionResult ChangePassword(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                ChangePasswordModel model = new ChangePasswordModel();
                model.Id = id;
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!AuthorizeService.AuthorizeUser(User, model.Id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    UserService.ChangePassword(model.Id, model.Password);
                    return RedirectToAction("Success");
                }
                else
                {
                    return View(model);
                }
            }
        }
        public IActionResult Details(int id)
        {
            if(!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                User user = UserService.GetById(id);
                UserDetailsModel model = ModelConverter.ConvertToUserDetailsModel(user);
                return View(model);
            }
        }
        public IActionResult GiveAdminRole(int id)
        {
            if(!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                UserService.GiveAdminRole(id);
                return RedirectToAction("ModifyUsersOverview");
            }
        }
        public IActionResult RemoveAdminRole(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            else
            {
                UserService.RemoveAdminRole(id);
            }
            if(Convert.ToInt32(User.FindFirst("Id").Value) == id)
            {
                return RedirectToAction("SignOut", "Auth");
            }
            else
            {
                return RedirectToAction("ModifyUsersOverview");
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}