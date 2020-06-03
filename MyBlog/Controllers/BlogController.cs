using Microsoft.AspNetCore.Mvc;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;
using MyBlog.ViewModels;
using System.Linq;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService BlogService { get; set; }
        public BlogController(IBlogService blogService)
        {
            BlogService = blogService;
        }
        public IActionResult Overview(string title)
        {
            var blogs = BlogService.GetByTitle(title);

            var overviewModels = blogs
                .Select(x => ModelConverter.OverviewModelConvert(x))
                .ToList();

            return View(overviewModels);
        }
        public IActionResult Details(int id)
        {
            var currentBlog = BlogService.GetBlogDetails(id);
            var model = ModelConverter.ConvertToDetailsModel(currentBlog);
            return View(model);
        }

        public IActionResult Create()
        {
            var blog = new BlogCreateModel();
            return View(blog);
        }
        [HttpPost]
        public IActionResult Create(BlogCreateModel blogCreate)
        {
            if (ModelState.IsValid)
            {
                var blog = ModelConverter.ConvertFromBlogCreateModel(blogCreate);
                BlogService.Add(blog);
                return RedirectToAction("Overview");
            }
            else
            {
                return View(blogCreate);
            }
        }
        public IActionResult Delete(int id)
        {
            BlogService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }
        public IActionResult ModifyOverview()
        {
            var blogs = BlogService.GetAll();

            var models = blogs
                .Select(x => ModelConverter.ConvertToModifyOverviewModel(x))
                .ToList();

            return View(models);
        }
        public IActionResult Modify(int id)
        {
            var blog = BlogService.GetById(id);
            var model = ModelConverter.ConvertToBlogModifyModel(blog);
            return View(model);
        }
        [HttpPost]
        public IActionResult Modify(BlogModifyModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = ModelConverter.ConvertFromBlogModifyModel(model);
                BlogService.UpdateBlog(blog);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(model);
            }
        }
    }
}