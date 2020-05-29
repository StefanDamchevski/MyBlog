﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using MyBlog.Data;
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
        public IActionResult Overview(string title)
        {
            var blogs = BlogService.GetByTitle(title);
            return View(blogs);
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
    }
}