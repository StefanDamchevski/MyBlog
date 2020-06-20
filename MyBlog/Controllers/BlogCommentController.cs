using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    [Authorize]
    public class BlogCommentController : Controller
    {
        private IBlogCommentService BlogCommentService { get; set; }
        public BlogCommentController(IBlogCommentService blogCommentService)
        {
            BlogCommentService = blogCommentService;
        }
        public IActionResult Add(string comment, int blogId)
        {
            if (!String.IsNullOrEmpty(comment))
            {
                int userId = Convert.ToInt32(User.FindFirst("Id").Value);
                BlogCommentService.Add(comment,blogId,userId);
                return RedirectToAction("Details", "Blog", new { id = blogId });
            }
            else
            {
                return RedirectToAction("Details", "Blog", new { id = blogId });
            }
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult ModifyCommentOverview()
        {
            List<BlogComment> blogComment = BlogCommentService.GetAll();
            List<ModifyCommentOverviewModel> model = blogComment
                .Select(x => ModelConverter.ConvertToModifyCommentOverviewModel(x))
                .ToList();

            return View(model);
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Apporve(int id)
        {
            BlogCommentService.Approve(id);
            return RedirectToAction("ModifyCommentOverview");
        }
        [Authorize(Policy ="IsAdmin")]
        public IActionResult Delete(int id)
        {
            BlogCommentService.Delete(id);
            return RedirectToAction("ModifyCommentOverview");
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Modify(int id)
        {
            BlogComment blogComment = BlogCommentService.GetById(id);
            ModifyCommentModel model = ModelConverter.ConvertToModifyCommentModel(blogComment);
            return View(model);
        }
        [Authorize(Policy = "IsAdmin")]
        [HttpPost]
        public IActionResult Modify(ModifyCommentModel model)
        {
            if (ModelState.IsValid)
            {
                BlogCommentService.Update(model.Id, model.Comment);
                return RedirectToAction("ModifyCommentOverview");
            }
            else
            {
                return View(model);
            }
        }
    }
}