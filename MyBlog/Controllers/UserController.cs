using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class UserController : Controller
    {
        public IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }
        public IActionResult ModifyUsersOverview()
        {
            var users = UserService.GetAll();
            var model = users
                .Select(x => ModelConverter.ConvertToModifyUsersOverviewModel(x))
                .ToList();

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            UserService.Delete(id);
            return RedirectToAction("ModifyUsersOverview");
        }
        public IActionResult ModifyUser(int id)
        {
            User user = UserService.GetById(id);
            var model = ModelConverter.ConvertToModifyUserModel(user);
            return View(model);
        }
        [HttpPost]
        public IActionResult ModifyUser(ModifyUserModel modifyUserModel)
        {
            if (ModelState.IsValid)
            {
                var user = ModelConverter.ConvertFromModifyUserModel(modifyUserModel);
                UserService.UpdateUser(user);
                return RedirectToAction("ModifyUsersOverview");
            }
            else
            {
                return View(modifyUserModel);
            }
        }
    }
}