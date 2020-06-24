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
    public class BlogController : Controller
    {
        private IBlogService BlogService { get; set; }
        public BlogController(IBlogService blogService)
        {
            BlogService = blogService;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            BlogOverviewData model = new BlogOverviewData();

            model.SidebarData = BlogService.GetSidebarData();

            model.BlogsOverview = BlogService.GetByTitle(title)
                .Select(x => ModelConverter.OverviewModelConvert(x))
                .ToList(); ;

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Blog blog = BlogService.GetBlogDetails(id);

            BlogDetailsModel model = ModelConverter.ConvertToDetailsModel(blog);

            model.SidebarData = BlogService.GetSidebarData();

            if (User.Identity.IsAuthenticated)
            {
                BlogLikeModel blogLike = model.BlogLikes.FirstOrDefault(x => x.UserId == Convert.ToInt32(User.FindFirst("Id").Value));
                if(blogLike != null)
                {
                    if (blogLike.Status)
                    {
                        model.LikeStatus = BlogLikeStatus.Liked;
                    }
                    else
                    {
                        model.LikeStatus = BlogLikeStatus.Disliked;
                    }
                }
            }

            return View(model);
        }
        public IActionResult Create()
        {
            BlogCreateModel model = new BlogCreateModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(BlogCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Blog blog = ModelConverter.ConvertFromBlogCreateModel(model);
                BlogService.Add(blog);
                return RedirectToAction("Overview");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(int id)
        {
            BlogService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult ModifyOverview()
        {
            List<Blog> blogs = BlogService.GetAll();

            List<ModifyOverviewModel> models = blogs
                .Select(x => ModelConverter.ConvertToModifyOverviewModel(x))
                .ToList();

            return View(models);
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Modify(int id)
        {
            Blog blog = BlogService.GetById(id);
            BlogModifyModel model = ModelConverter.ConvertToBlogModifyModel(blog);
            return View(model);
        }
        [Authorize(Policy = "IsAdmin")]
        [HttpPost]
        public IActionResult Modify(BlogModifyModel model)
        {
            if (ModelState.IsValid)
            {
                Blog blog = ModelConverter.ConvertFromBlogModifyModel(model);
                BlogService.UpdateBlog(blog);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(model);
            }
        }
        [Authorize(Policy ="IsAdmin")]
        public IActionResult Apporve(int id)
        {
            BlogService.Approve(id);
            return RedirectToAction("ModifyOverview");
        }
    }
}