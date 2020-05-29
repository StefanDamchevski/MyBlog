using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using MyBlog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository BlogRepository { get; set; }
        public BlogService(IBlogRepository blogRepository)
        {
            BlogRepository = blogRepository;
        }
        public void Add(Blog blog)
        {
            BlogRepository.Add(blog);
        }
        public List<Blog> GetByTitle(string title)
        {
           return BlogRepository.GetByTitle(title);
        }

        public Blog GetById(int id)
        {
            return BlogRepository.GetById(id);
        }

        public List<Blog> GetAll()
        {
            return BlogRepository.GetAll();
        }

        public Blog GetBlogDetails(int id)
        {
            var blog = BlogRepository.GetById(id);
            blog.Views += 1;
            BlogRepository.Update(blog);
            return blog;
        }
    }
}
