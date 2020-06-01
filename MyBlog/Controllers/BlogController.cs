using Microsoft.AspNetCore.Mvc;
using MyBlog.Data;
using MyBlog.Helpers;
using MyBlog.Service.Interfaces;
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
                .Select(x => OverviewModelConverter.OverviewModelConvert(x))
                .ToList();

            return View(overviewModels);
        }
        public IActionResult Details(int id)
        {
            var currentBlog = BlogService.GetBlogDetails(id);
            return View(currentBlog);
        }

        public IActionResult Create()
        {
            var blog = new Blog();
            return View(blog);
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                BlogService.Add(blog);
                return RedirectToAction("Overview");
            }
            else
            {
                return View(blog);
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
            return View(blogs);
        }
        public IActionResult Modify(int id)
        {
            var blog = BlogService.GetById(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult Modify(Blog blog)
        {
            if (ModelState.IsValid)
            {
                BlogService.UpdateBlog(blog);
                return RedirectToAction("ModifyOverview");
            }
            else
            {
                return View(blog);
            }
        }
    }
}