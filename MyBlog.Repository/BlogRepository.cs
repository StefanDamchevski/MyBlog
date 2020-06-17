using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private MyBlogsContext Context { get; set; }
        public BlogRepository(MyBlogsContext context)
        {
            Context = context;
        }
        public void Add(Blog blog)
        {
            blog.DateCreated = DateTime.Now;
            Context.Blogs.Add(blog);
            Context.SaveChanges();
        }
        public List<Blog> GetAll()
        {
            return Context.Blogs.ToList();
        }
        public Blog GetById(int id)
        {
            return Context.Blogs
                .Include(x => x.BlogComments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }
        public List<Blog> GetByTitle(string title)
        {
            IQueryable<Blog> blogs = Context.Blogs.AsQueryable();
            if (!String.IsNullOrEmpty(title))
            {
                blogs = blogs.Where(x => x.Title.Contains(title));
            }
            return blogs.ToList();
        }
        public void Update(Blog blog)
        {
            Context.Blogs.Update(blog);
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            Blog blog = new Blog()
            {
                Id = id,
            };

            Context.Blogs.Remove(blog);
            Context.SaveChanges();
        }
    }
}