using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using MyBlog.Models;
using MyBlog.Service.Interfaces;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService BlogService { get; set; }
        public BlogController(IBlogService blogService)
        {
            BlogService = blogService;
        }
        public IActionResult Overview()
        {
            var blogs = BlogService.GetAll();
            return View(blogs);
        }
        public IActionResult Details(int id)
        {
            var currentBlog = BlogService.GetById(id);
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
    }
}